using Mimisbrunnr.Shared.Sponsors.Dtos;

namespace Mimisbrunnr.Shared.Sponsors;

public partial class SponsorResponse
{
    public class GetSponsorsForHomePage
    {
        public required IReadOnlyList<SponsorDto.Simple> Sponsors { get; set; }
    }
}