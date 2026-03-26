using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class PostErelid(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PostErelid, PraesidiumResponse.PostErelid>
{
    public override void Configure()
    {
        Post("/api/praesidium/erelids");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.PostErelid> ExecuteAsync(PraesidiumRequest.PostErelid req, CancellationToken ct)
    {
        return praesidiumService.PostErelid(req, ct);
    }
}