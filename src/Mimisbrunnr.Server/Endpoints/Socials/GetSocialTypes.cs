using Mimisbrunnr.Shared.Socials;

namespace Mimisbrunnr.Server.Endpoints.Socials;

public class GetSocialTypes(ISocialService socialService) : EndpointWithoutRequest<Result<SocialResponse.GetSocialTypes>>
{
    public override void Configure()
    {
        Get("/api/socials/types");
    }

    public override Task<Result<SocialResponse.GetSocialTypes>> ExecuteAsync(CancellationToken ct)
    {
        return socialService.GetSocialTypes(ct);
    }
}