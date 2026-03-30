namespace Mimisbrunnr.Shared.Common.Dtos;

public static class ImageDto
{
    public class Simple
    {
        public required string Url { get; set; }
        public string? Description { get; set; }
    }
    
    public class Detailed : Simple
    {
        public required int Id { get; set; }
    }

}