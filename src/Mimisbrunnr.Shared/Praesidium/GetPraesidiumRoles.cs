using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class GetPraesidiumRoles
    {
        public required IReadOnlyList<PraesidiumRoleDto.Simple> Roles { get; set; }
    }
}