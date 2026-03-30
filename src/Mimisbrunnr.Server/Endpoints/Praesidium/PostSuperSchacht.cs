using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class PostSuperSchacht(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PostSuperSchacht, Result<PraesidiumResponse.PostSuperSchacht>>
{
    public override void Configure()
    {
        Post("/api/praesidium/superschachts");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.PostSuperSchacht>> ExecuteAsync(PraesidiumRequest.PostSuperSchacht req, CancellationToken ct)
    {
        return praesidiumService.PostSuperSchacht(req, ct);
    }
}