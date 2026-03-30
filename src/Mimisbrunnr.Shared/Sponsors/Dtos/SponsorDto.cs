using Mimisbrunnr.Shared.Common.Dtos;

namespace Mimisbrunnr.Shared.Sponsors.Dtos;

public static class SponsorDto
{
    public class Simple
    {
        public required string Name  { get; set; }

        public required ImageDto.Simple Logo  { get; set; }

        public required string Website   { get; set; }

        public required int Order { get;set; }
    }
    
    public class Detailed
    {
        public required string Name  { get; set; }

        public required ImageDto.Simple Logo  { get; set; }

        public required string Website   { get; set; }

        public required string Benefits   { get; set; }

        public required string? Rank { get; set; }
        
        public required string? LanSponsorRank { get; set; }
        
        public required int Order { get;set; }
    }
}