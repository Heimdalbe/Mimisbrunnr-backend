using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class PostLustrumLid(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PostLustrumLid, PraesidiumResponse.PostLustrumLid>
{
    public override void Configure()
    {
        Post("/api/praesidium/lustrum/members");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.PostLustrumLid> ExecuteAsync(PraesidiumRequest.PostLustrumLid req, CancellationToken ct)
    {
        return praesidiumService.PostLustrumLid(req, ct);
    }
}