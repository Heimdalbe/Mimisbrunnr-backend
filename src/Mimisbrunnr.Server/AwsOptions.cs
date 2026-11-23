using Amazon;
using Amazon.Runtime;
using Amazon.S3;

namespace Mimisbrunnr.Server;

public class AwsOptions
{
    public string AccessKey { get; set; } = "";
    public string SecretKey { get; set; } = "";
    public string Region { get; set; } = "eu-west-2";
    public string Bucket { get; set; } = "";
    public string? ServiceUrl { get; set; }

    public string PublicBaseUrl => string.IsNullOrWhiteSpace(ServiceUrl)
        ? $"https://{Bucket}.s3.{Region}.amazonaws.com"
        : $"{ServiceUrl.TrimEnd('/')}/{Bucket}";

    public AmazonS3Client CreateClient()
    {
        var credentials = new BasicAWSCredentials(AccessKey, SecretKey);
        return string.IsNullOrWhiteSpace(ServiceUrl)
            ? new AmazonS3Client(credentials, RegionEndpoint.GetBySystemName(Region))
            : new AmazonS3Client(credentials, new AmazonS3Config
            {
                ServiceURL = ServiceUrl,
                ForcePathStyle = true,
                AuthenticationRegion = Region
            });
    }
}
