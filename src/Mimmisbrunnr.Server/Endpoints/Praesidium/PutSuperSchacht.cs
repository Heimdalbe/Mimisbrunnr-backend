using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class PutSuperSchacht(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PutSuperSchacht, PraesidiumResponse.PutSuperSchacht>
{
    public override void Configure()
    {
        Post("/api/praesidium/superschachts/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.PutSuperSchacht> ExecuteAsync(PraesidiumRequest.PutSuperSchacht req, CancellationToken ct)
    {
        var id = Route<int>("id");
        return praesidiumService.PutSuperSchacht(id,req, ct);
    }
}