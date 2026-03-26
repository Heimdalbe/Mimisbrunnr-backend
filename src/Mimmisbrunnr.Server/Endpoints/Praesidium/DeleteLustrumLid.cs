using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class DeleteLustrumLid(IPraesidiumService praesidiumService) : EndpointWithoutRequest<PraesidiumResponse.DeleteLustrumlid>
{
    public override void Configure()
    {
        Delete("/api/praesidium/lustrum/members/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.DeleteLustrumlid> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.DeleteLustrumLid(id, ct);
    }
}