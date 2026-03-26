namespace Mimmisbrunnr.Shared.Common.Dtos;

public static class SocialDto
{
    public class Simple
    {
        public required SocialTypeDto.Simple Type {get; set;}
        public required string Url { get; set; }
    }
    
    public class Detailed : Simple
    {
        public required int Id {get; set;}
    }
}