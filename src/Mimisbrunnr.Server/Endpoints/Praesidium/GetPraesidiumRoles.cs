using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;
using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetPraesidiumRoles(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.GetPraesidiumRoles>>
{
    public override void Configure()
    {
        Get("/api/praesidium/roles");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.GetPraesidiumRoles>> ExecuteAsync(CancellationToken ct)
    {
        return praesidiumService.GetPraesidiumRoles(ct);
    }
}