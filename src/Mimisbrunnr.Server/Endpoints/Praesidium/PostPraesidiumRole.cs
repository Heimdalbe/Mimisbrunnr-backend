using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class PostPraesidiumRole(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PostPraesidiumRole, Result<PraesidiumResponse.PostPraesidiumRole>>
{
    public override void Configure()
    {
        Post("/api/praesidium/roles");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.PostPraesidiumRole>> ExecuteAsync(PraesidiumRequest.PostPraesidiumRole req, CancellationToken ct)
    {
        return praesidiumService.PostPraesidiumRole(req, ct);
    }
}   