using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Socials;

namespace Mimisbrunnr.Server.Endpoints.Socials;

public class PutSocialType(ISocialService socialService) : Endpoint<SocialRequest.PutSocialType, Result<SocialResponse.PutSocialType>>
{
    public override void Configure()
    {
        Put("/api/socials/types/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<SocialResponse.PutSocialType>> ExecuteAsync(SocialRequest.PutSocialType req, CancellationToken ct)
    {
        int id = Route<int>("id");
        return socialService.PutSocialType(id, req, ct);
    }
}