using Mimisbrunnr.Shared.Socials;
using Mimisbrunnr.Shared.Socials.Dtos;

namespace Mimisbrunnr.Server.Endpoints.Socials;

public class GetSocialById(ISocialService socialService) : EndpointWithoutRequest<Result<SocialDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/socials/{id:int}");
    }

    public override Task<Result<SocialDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return socialService.GetSocial(id, ct);
    }
}