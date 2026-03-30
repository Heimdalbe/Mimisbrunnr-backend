using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class PostErelid(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PostErelid, Result<PraesidiumResponse.PostErelid>>
{
    public override void Configure()
    {
        Post("/api/praesidium/erelids");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.PostErelid>> ExecuteAsync(PraesidiumRequest.PostErelid req, CancellationToken ct)
    {
        return praesidiumService.PostErelid(req, ct);
    }
}