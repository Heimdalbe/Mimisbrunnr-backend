using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class PostPraesidiumMember(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PostPraesidiumMember, PraesidiumResponse.PostPraesidiumMember>
{
    public override void Configure()
    {
        Post("/api/praesidium/members");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.PostPraesidiumMember> ExecuteAsync(PraesidiumRequest.PostPraesidiumMember req, CancellationToken ct)
    {
        return praesidiumService.PostPraesidiumMember(req,ct);
    }
}