using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class DeletePraesidiumRole(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.DeletePraesidiumRole>>
{
    public override void Configure()
    {
        Delete("/api/praesidium/roles/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.DeletePraesidiumRole>> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.DeletePraesidiumRole(id, ct);
    }
}