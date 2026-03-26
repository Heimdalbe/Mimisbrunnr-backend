using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class PutLustrumLid(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PutLustrumLid, PraesidiumResponse.PutLustrumLid>
{
    public override void Configure()
    {
        Post("/api/praesidium/lustrum/members/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.PutLustrumLid> ExecuteAsync(PraesidiumRequest.PutLustrumLid req, CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.PutLustrumLid(id, req, ct);
    }
}