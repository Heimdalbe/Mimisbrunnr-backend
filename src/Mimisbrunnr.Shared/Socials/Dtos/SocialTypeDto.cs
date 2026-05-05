using Mimisbrunnr.Shared.Common.Dtos;

namespace Mimisbrunnr.Shared.Socials.Dtos;

public static class SocialTypeDto
{
    public class Simple
    {
        public required int Id {get; set;}
        public required string Name { get; set; }
    }

    public class Detailed
    {
        public required int Id {get; set;}
        public required string Name { get; set; }
    }
}