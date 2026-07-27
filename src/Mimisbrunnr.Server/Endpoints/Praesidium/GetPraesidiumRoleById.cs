using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;
using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetPraesidiumRoleById(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumRoleDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/praesidium/roles/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumRoleDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        return praesidiumService.GetPraesidiumRoleDetailed(id, ct);
    }
}