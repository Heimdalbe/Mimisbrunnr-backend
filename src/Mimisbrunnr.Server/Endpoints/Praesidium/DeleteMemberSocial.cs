using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class DeleteMemberSocial(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.DeleteMemberSocial>>
{
    public override void Configure()
    {
        Delete("/api/members/{memberId:int}/socials/{SocialId:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.DeleteMemberSocial>> ExecuteAsync(CancellationToken ct)
    {
        var memberId = Route<int>("memberId");
        var socialId = Route<int>("socialId");

        return praesidiumService.DeleteMemberSocial(memberId, socialId, ct);
    }
}