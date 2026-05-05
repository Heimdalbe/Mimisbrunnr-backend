using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;
using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetPraesidiaMembers(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.GetPraesidiaMembers>>
{
    public override void Configure()
    {
        Get("/api/praesidium/members");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.GetPraesidiaMembers>> ExecuteAsync(CancellationToken ct)
    {
        return praesidiumService.GetPraesidiaMembers(ct);
    }
}