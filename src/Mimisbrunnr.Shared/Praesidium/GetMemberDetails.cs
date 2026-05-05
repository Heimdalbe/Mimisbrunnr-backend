using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetMemberDetails
    {
        public required IReadOnlyList<MemberDetailsDto.Simple> Members { get; set; }
    }
}