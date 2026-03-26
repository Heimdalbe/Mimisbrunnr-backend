namespace Mimmisbrunnr.Shared.Common.Dtos;

public static class SocialTypeDto
{
    public class Simple
    {
        public required ImageDto.Simple Icon { get; set; }
    }

    public class Detailed : Simple
    {
        public required int Id {get; set;}
        public required string Name { get; set; }
    }
}