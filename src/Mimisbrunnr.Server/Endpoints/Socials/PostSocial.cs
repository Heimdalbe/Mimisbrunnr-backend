using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Socials;

namespace Mimisbrunnr.Server.Endpoints.Socials;

public class PostSocial(ISocialService socialService) : Endpoint<SocialRequest.PostSocial, Result<SocialResponse.PostSocial>>
{
    public override void Configure()
    {
        Post("/api/socials");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<SocialResponse.PostSocial>> ExecuteAsync(SocialRequest.PostSocial req, CancellationToken ct)
    {
        return socialService.PostSocial(req, ct);
    }
}