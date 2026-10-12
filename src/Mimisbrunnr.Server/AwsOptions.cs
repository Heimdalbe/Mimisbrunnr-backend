namespace Mimisbrunnr.Server;

public class AwsOptions
{
    public string AccessKey { get; set; } = "";
    public string SecretKey { get; set; } = "";
    public string Region { get; set; } = "eu-west-2";
    public string Bucket { get; set; } = "";
}