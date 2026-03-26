using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class PostPraesidiumRole(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PostPraesidiumRole, PraesidiumResponse.PostPraesidiumRole>
{
    public override void Configure()
    {
        Post("/api/praesidium/roles");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.PostPraesidiumRole> ExecuteAsync(PraesidiumRequest.PostPraesidiumRole req, CancellationToken ct)
    {
        return praesidiumService.PostPraesidiumRole(req, ct);
    }
}   