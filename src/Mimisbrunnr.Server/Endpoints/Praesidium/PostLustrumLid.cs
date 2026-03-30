using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class PostLustrumLid(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PostLustrumLid, Result<PraesidiumResponse.PostLustrumLid>>
{
    public override void Configure()
    {
        Post("/api/praesidium/lustrum/members");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.PostLustrumLid>> ExecuteAsync(PraesidiumRequest.PostLustrumLid req, CancellationToken ct)
    {
        return praesidiumService.PostLustrumLid(req, ct);
    }
}