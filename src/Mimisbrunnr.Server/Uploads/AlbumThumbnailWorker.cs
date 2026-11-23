using System.Security.Cryptography;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Mimisbrunnr.Persistence;
using SkiaSharp;

namespace Mimisbrunnr.Server.Uploads;

internal sealed class AlbumThumbnailWorker(
    IServiceScopeFactory scopes,
    IHttpClientFactory httpClients,
    IOptions<AwsOptions> options,
    ILogger<AlbumThumbnailWorker> logger) : BackgroundService
{
    internal const string HttpClientName = "AlbumThumbnails";
    private const int MaxSourceBytes = 24 * 1024 * 1024;
    private const int MaxSourcePixels = 50_000_000;
    private const int MaxPreviewSide = 960;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var aws = options.Value;
        if (string.IsNullOrWhiteSpace(aws.Bucket) || string.IsNullOrWhiteSpace(aws.AccessKey)
            || string.IsNullOrWhiteSpace(aws.SecretKey))
            return;

        var bucket = new Uri(aws.PublicBaseUrl + "/");
        using var s3 = aws.CreateClient();
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
        do
        {
            try
            {
                using var http = httpClients.CreateClient(HttpClientName);
                await GeneratePendingAsync(http, s3, bucket, aws.Bucket, stoppingToken);
            }
            catch (Exception ex) when (!stoppingToken.IsCancellationRequested)
            {
                logger.LogWarning(ex, "Could not process pending album thumbnails");
            }
        } while (await timer.WaitForNextTickAsync(stoppingToken));
    }

    private async Task GeneratePendingAsync(
        HttpClient http, IAmazonS3 s3, Uri bucket, string bucketName, CancellationToken ct)
    {
        var beforeId = int.MaxValue;
        var retryBefore = DateTime.UtcNow;
        while (!ct.IsCancellationRequested)
        {
            await using var scope = scopes.CreateAsyncScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var images = await db.Images
                .Where(image => image.Id < beforeId && image.ThumbnailUrl == null
                    && (image.ThumbnailRetryAfter == null || image.ThumbnailRetryAfter <= retryBefore)
                    && (image.Url.StartsWith(bucket.AbsoluteUri) || image.Url.StartsWith("https://i.imgur.com/")
                        || image.Url.StartsWith("http://i.imgur.com/"))
                    && db.Albums.Any(album => album.CoverImage == image || album.Images.Contains(image)))
                .OrderByDescending(image => image.Id)
                .Take(20)
                .ToListAsync(ct);
            if (images.Count == 0)
                return;

            foreach (var image in images)
            {
                try
                {
                    using var timeout = CancellationTokenSource.CreateLinkedTokenSource(ct);
                    timeout.CancelAfter(TimeSpan.FromSeconds(30));
                    image.ThumbnailUrl = await GenerateAsync(image.Url, http, s3, bucket, bucketName, timeout.Token);
                }
                catch (Exception ex) when (!ct.IsCancellationRequested)
                {
                    logger.LogWarning(ex, "Could not generate thumbnail for album image {ImageId}", image.Id);
                }

                image.ThumbnailRetryAfter = image.ThumbnailUrl == null ? DateTime.UtcNow.AddHours(1) : null;
                await db.SaveChangesAsync(ct);
            }
            beforeId = images[^1].Id;
        }
    }

    private static async Task<string?> GenerateAsync(
        string url, HttpClient http, IAmazonS3 s3, Uri bucket, string bucketName, CancellationToken ct)
    {
        var source = GetSourceUri(url, bucket);
        if (source is null)
            return null;

        using var response = await http.GetAsync(source, HttpCompletionOption.ResponseHeadersRead, ct);
        response.EnsureSuccessStatusCode();
        if (response.Content.Headers.ContentLength > MaxSourceBytes)
            return null;

        await using var input = await response.Content.ReadAsStreamAsync(ct);
        using var original = new MemoryStream();
        var buffer = new byte[81920];
        int size;
        while ((size = await input.ReadAsync(buffer, ct)) > 0)
        {
            if (original.Length + size > MaxSourceBytes)
                return null;

            original.Write(buffer, 0, size);
        }

        original.Position = 0;
        using var codec = SKCodec.Create(original);
        if (codec is null || (long)codec.Info.Width * codec.Info.Height > MaxSourcePixels)
            return null;

        using var preview = EncodePreview(codec);
        if (preview is null)
            return null;

        using var encoded = preview.AsStream();
        var hash = Convert.ToHexStringLower(SHA256.HashData(encoded));
        var key = $"albums/thumbnails/{hash}.webp";
        encoded.Position = 0;
        var upload = new PutObjectRequest
        {
            BucketName = bucketName,
            Key = key,
            InputStream = encoded,
            ContentType = "image/webp"
        };
        upload.Headers.CacheControl = "public,max-age=31536000,immutable";
        await s3.PutObjectAsync(upload, ct);
        return new Uri(bucket, key).AbsoluteUri;
    }

    private static SKData? EncodePreview(SKCodec codec)
    {
        var info = codec.Info;
        var scale = Math.Min(1.0, (double)MaxPreviewSide / Math.Max(info.Width, info.Height));
        var width = Math.Max(1, (int)Math.Round(info.Width * scale));
        var height = Math.Max(1, (int)Math.Round(info.Height * scale));
        var origin = codec.EncodedOrigin;
        var swapped = origin is SKEncodedOrigin.LeftTop or SKEncodedOrigin.RightTop
            or SKEncodedOrigin.RightBottom or SKEncodedOrigin.LeftBottom;

        using var original = SKBitmap.Decode(codec);
        if (original is null)
            return null;

        using var target = new SKBitmap(swapped ? height : width, swapped ? width : height);
        using var canvas = new SKCanvas(target);
        switch (origin)
        {
            case SKEncodedOrigin.TopRight:
                canvas.Translate(width, 0);
                canvas.Scale(-1, 1);
                break;
            case SKEncodedOrigin.BottomRight:
                canvas.Translate(width, height);
                canvas.RotateDegrees(180);
                break;
            case SKEncodedOrigin.BottomLeft:
                canvas.Translate(0, height);
                canvas.Scale(1, -1);
                break;
            case SKEncodedOrigin.LeftTop:
                canvas.RotateDegrees(90);
                canvas.Scale(1, -1);
                break;
            case SKEncodedOrigin.RightTop:
                canvas.Translate(height, 0);
                canvas.RotateDegrees(90);
                break;
            case SKEncodedOrigin.RightBottom:
                canvas.Translate(height, width);
                canvas.RotateDegrees(90);
                canvas.Scale(-1, 1);
                break;
            case SKEncodedOrigin.LeftBottom:
                canvas.Translate(0, width);
                canvas.RotateDegrees(-90);
                break;
        }

        using var image = SKImage.FromBitmap(original);
        canvas.DrawImage(image, new SKRect(0, 0, width, height),
            new SKSamplingOptions(SKCubicResampler.Mitchell));
        using var resized = SKImage.FromBitmap(target);
        return resized.Encode(SKEncodedImageFormat.Webp, 86);
    }

    private static Uri? GetSourceUri(string url, Uri bucket)
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out var source) || source.UserInfo.Length != 0)
            return null;

        if (bucket.IsBaseOf(source))
            return source;

        return source.Host == "i.imgur.com" && source.IsDefaultPort
            && (source.Scheme == Uri.UriSchemeHttps || source.Scheme == Uri.UriSchemeHttp)
            ? new UriBuilder(source) { Scheme = Uri.UriSchemeHttps, Port = -1 }.Uri
            : null;
    }
}
