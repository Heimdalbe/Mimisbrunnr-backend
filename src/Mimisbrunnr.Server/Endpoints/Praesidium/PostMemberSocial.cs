using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class PostMemberSocial(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PostMemberSocial,Result<PraesidiumResponse.PostMemberSocial>>
{
    public override void Configure()
    {
        Post("/api/members/{memberId:int}/socials");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.PostMemberSocial>> ExecuteAsync(PraesidiumRequest.PostMemberSocial req, CancellationToken ct)
    {
        var memberId = Route<int>("memberId");

        return praesidiumService.PostMemberSocial(memberId, req, ct);
    }
}