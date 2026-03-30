using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class PutLustrumLid(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PutLustrumLid, Result<PraesidiumResponse.PutLustrumLid>>
{
    public override void Configure()
    {
        Post("/api/praesidium/lustrum/members/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.PutLustrumLid>> ExecuteAsync(PraesidiumRequest.PutLustrumLid req, CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.PutLustrumLid(id, req, ct);
    }
}