using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Uploads;

using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using FastEndpoints;
using Microsoft.Extensions.Options;

public class PresignRequest
{
    public string ContentType { get; set; } = "";
    public string Folder { get; set; } = "";
}

public class PresignResponse
{
    public string UploadUrl { get; set; } = "";
    public string PublicUrl { get; set; } = "";
}

public class PresignUploadEndpoint(IOptions<AwsOptions> options) : Endpoint<PresignRequest, PresignResponse>
{
    private static readonly Dictionary<string, string> Extensions = new()
    {
        ["image/jpeg"] = "jpg",
        ["image/png"] = "png",
        ["image/webp"] = "webp"
    };

    // folder -> roles allowed to upload there
    private static readonly Dictionary<string, string[]> FolderRoles = new()
    {
        ["events"] = [AppRoles.EventEditor, AppRoles.Hmdl],
        ["sponsors"] = [AppRoles.SponsorEditor, AppRoles.Hmdl]
    };

    public override void Configure()
    {
        Post("/api/uploads/presign");
        Roles(AppRoles.EventEditor, AppRoles.SponsorEditor, AppRoles.Hmdl);
    }

    public override async Task HandleAsync(PresignRequest req, CancellationToken ct)
    {
        if (!Extensions.TryGetValue(req.ContentType, out var ext))
        {
            ThrowError("Only JPEG, PNG or WebP images are allowed.");
            return;
        }

        if (!FolderRoles.TryGetValue(req.Folder, out var allowedRoles))
        {
            ThrowError("Unknown upload folder.");
            return;
        }

        if (!allowedRoles.Any(User.IsInRole))
        {
            await Send.ForbiddenAsync(ct);
            return;
        }

        var aws = options.Value;
        var key = $"{req.Folder}/{Guid.NewGuid():N}.{ext}";

        using var client = new AmazonS3Client(
            new BasicAWSCredentials(aws.AccessKey, aws.SecretKey),
            RegionEndpoint.GetBySystemName(aws.Region));

        var uploadUrl = client.GetPreSignedURL(new GetPreSignedUrlRequest
        {
            BucketName = aws.Bucket,
            Key = key,
            Verb = HttpVerb.PUT,
            Expires = DateTime.UtcNow.AddMinutes(5),
            ContentType = req.ContentType
        });

        await Send.OkAsync(new PresignResponse
        {
            UploadUrl = uploadUrl,
            PublicUrl = $"https://{aws.Bucket}.s3.{aws.Region}.amazonaws.com/{key}"
        }, ct);
    }
}