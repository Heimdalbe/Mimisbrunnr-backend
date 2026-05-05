using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetLustrumLids(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.GetLustrumLids>>
{
    public override void Configure()
    {
        Get("/api/praesidium/lustrum/members");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.GetLustrumLids>> ExecuteAsync(CancellationToken ct)
    {
        return praesidiumService.GetLustrumLids(ct);
    }
}