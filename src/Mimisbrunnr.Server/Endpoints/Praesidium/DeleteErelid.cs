using Mimisbrunnr.Shared.Praesidium;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class DeleteErelid(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.DeleteErelid>>
{
    public override void Configure()
    {
        Delete("/api/praesidium/erelids/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.DeleteErelid>> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.DeleteErelid(id, ct);
    }
}