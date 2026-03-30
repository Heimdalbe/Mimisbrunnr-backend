using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class DeleteLustrumLid(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.DeleteLustrumlid>>
{
    public override void Configure()
    {
        Delete("/api/praesidium/lustrum/members/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.DeleteLustrumlid>> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.DeleteLustrumLid(id, ct);
    }
}