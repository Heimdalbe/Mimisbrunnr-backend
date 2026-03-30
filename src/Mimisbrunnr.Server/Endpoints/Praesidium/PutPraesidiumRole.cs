using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class PutPraesidiumRole(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PutPraesidiumRole, Result<PraesidiumResponse.PutPraesidiumRole>>
{
    public override void Configure()
    {
        Put("/api/praesidium/roles/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.PutPraesidiumRole>> ExecuteAsync(PraesidiumRequest.PutPraesidiumRole req, CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.PutPraesidiumRole(id, req, ct);
    }
}