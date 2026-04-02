using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Socials;

namespace Mimisbrunnr.Server.Endpoints.Socials;

public class PostSocialType(ISocialService socialService) : Endpoint<SocialRequest.PostSocialType, Result<SocialResponse.PostSocialType>>
{
    public override void Configure()
    {
        Post("/api/socials/types");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<SocialResponse.PostSocialType>> ExecuteAsync(SocialRequest.PostSocialType req, CancellationToken ct)
    {
        return socialService.PostSocialType(req, ct);
    }
}