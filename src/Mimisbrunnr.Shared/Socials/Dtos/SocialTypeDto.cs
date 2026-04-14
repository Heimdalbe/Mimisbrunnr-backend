using Mimisbrunnr.Shared.Common.Dtos;

namespace Mimisbrunnr.Shared.Socials.Dtos;

public static class SocialTypeDto
{
    public class Simple
    {
        public required ImageDto.Simple Icon { get; set; }
    }

    public class Detailed
    {
        public required int Id {get; set;}
        public required ImageDto.Simple Icon { get; set; }
        public required string Name { get; set; }
    }
}