using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class DeleteErelid(IPraesidiumService praesidiumService) : EndpointWithoutRequest<PraesidiumResponse.DeleteErelid>
{
    public override void Configure()
    {
        Delete("/api/praesidium/erelids/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.DeleteErelid> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.DeleteErelid(id, ct);
    }
}