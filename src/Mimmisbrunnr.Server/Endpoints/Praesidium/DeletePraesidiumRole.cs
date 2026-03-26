using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class DeletePraesidiumRole(IPraesidiumService praesidiumService) : EndpointWithoutRequest<PraesidiumResponse.DeletePraesidiumRole>
{
    public override void Configure()
    {
        Delete("/api/praesidium/roles/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.DeletePraesidiumRole> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.DeletePraesidiumRole(id, ct);
    }
}