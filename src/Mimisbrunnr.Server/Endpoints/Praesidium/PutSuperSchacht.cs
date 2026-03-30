using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class PutSuperSchacht(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PutSuperSchacht, Result<PraesidiumResponse.PutSuperSchacht>>
{
    public override void Configure()
    {
        Post("/api/praesidium/superschachts/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.PutSuperSchacht>> ExecuteAsync(PraesidiumRequest.PutSuperSchacht req, CancellationToken ct)
    {
        var id = Route<int>("id");
        return praesidiumService.PutSuperSchacht(id,req, ct);
    }
}