using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Socials;

namespace Mimisbrunnr.Server.Endpoints.Socials;

public class DeleteSocialType(ISocialService socialService) : EndpointWithoutRequest<Result<SocialResponse.DeleteSocialType>>
{
    public override void Configure()
    {
        Delete("/api/socials/types/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<SocialResponse.DeleteSocialType>> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return socialService.DeleteSocialType(id, ct);
    }
}