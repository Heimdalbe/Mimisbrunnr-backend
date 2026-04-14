using Mimisbrunnr.Shared.Socials;
using Mimisbrunnr.Shared.Socials.Dtos;

namespace Mimisbrunnr.Server.Endpoints.Socials;

public class GetSocialTypeById(ISocialService socialService) : EndpointWithoutRequest<Result<SocialTypeDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/socials/types/{id:int}");
    }

    public override Task<Result<SocialTypeDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return socialService.GetSocialType(id, ct);
    }
}