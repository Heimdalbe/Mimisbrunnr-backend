using Mimisbrunnr.Shared.Socials;

namespace Mimisbrunnr.Server.Endpoints.Socials;

public class GetSocials(ISocialService socialService) : EndpointWithoutRequest<Result<SocialResponse.GetSocials>>
{
    public override void Configure()
    {
        Get("/api/socials");
    }

    public override Task<Result<SocialResponse.GetSocials>> ExecuteAsync(CancellationToken ct)
    {
        return socialService.GetSocials(ct);
    }
}