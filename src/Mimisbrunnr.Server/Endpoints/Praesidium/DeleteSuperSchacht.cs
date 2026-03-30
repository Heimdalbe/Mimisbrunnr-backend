using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class DeleteSuperSchacht(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.DeleteSuperSchacht>>
{
    public override void Configure()
    {
        Delete("/api/praesidium/superschachts/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.DeleteSuperSchacht>> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.DeleteSuperSchacht(id, ct);
    }
}