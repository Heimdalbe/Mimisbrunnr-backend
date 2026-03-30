using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class PostPraesidiumMember(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PostPraesidiumMember, Result<PraesidiumResponse.PostPraesidiumMember>>
{
    public override void Configure()
    {
        Post("/api/praesidium/members");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.PostPraesidiumMember>> ExecuteAsync(PraesidiumRequest.PostPraesidiumMember req, CancellationToken ct)
    {
        return praesidiumService.PostPraesidiumMember(req,ct);
    }
}