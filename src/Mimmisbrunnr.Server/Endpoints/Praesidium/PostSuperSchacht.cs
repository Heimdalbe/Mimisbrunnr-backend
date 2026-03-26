using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class PostSuperSchacht(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PostSuperSchacht, PraesidiumResponse.PostSuperSchacht>
{
    public override void Configure()
    {
        Post("/api/praesidium/superschachts");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.PostSuperSchacht> ExecuteAsync(PraesidiumRequest.PostSuperSchacht req, CancellationToken ct)
    {
        return praesidiumService.PostSuperSchacht(req, ct);
    }
}