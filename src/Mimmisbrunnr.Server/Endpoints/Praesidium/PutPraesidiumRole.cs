using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class PutPraesidiumRole(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PutPraesidiumRole, PraesidiumResponse.PutPraesidiumRole>
{
    public override void Configure()
    {
        Put("/api/praesidium/roles/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.PutPraesidiumRole> ExecuteAsync(PraesidiumRequest.PutPraesidiumRole req, CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.PutPraesidiumRole(id, req, ct);
    }
}