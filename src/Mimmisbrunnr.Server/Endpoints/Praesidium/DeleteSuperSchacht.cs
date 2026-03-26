using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class DeleteSuperSchacht(IPraesidiumService praesidiumService) : EndpointWithoutRequest<PraesidiumResponse.DeleteSuperSchacht>
{
    public override void Configure()
    {
        Delete("/api/praesidium/superschachts/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.DeleteSuperSchacht> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.DeleteSuperSchacht(id, ct);
    }
}