using Mimisbrunnr.Shared.Common.Dtos;
using Mimisbrunnr.Shared.Sponsors.Dtos;

namespace Mimisbrunnr.Shared.Events.Dtos;

public static class EventDto
{
    public class Simple
    {
        public required string Category { get; set; }

        public required string Accessibility { get; set; }

        public required string Name { get; set; }

        public required DateTime? Start { get; set; }

        public required DateTime? End { get;set; }

        public required ImageDto.Simple? Banner;

        public required string? EntryFee { get; set; }
        
        public required bool Published { get; set; }
    }
    
    public class Detailed
    {
        public required string Category { get; set; }

        public required string Accessibility { get; set; }

        public required string Name { get; set; }

        public required string? Location { get; set; }

        public required DateTime? Start { get; set; }

        public required DateTime? End { get;set; }

        public required string? Description { get; set; }

        public required string? ICal { get;set; }

        public required ImageDto.Simple? Banner;

        public required SponsorDto.Simple[] Sponsors;

        public required string? EntryFee { get; set; }
        
        public required bool Published { get; set; }
    }
}