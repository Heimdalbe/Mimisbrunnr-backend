using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Socials;

namespace Mimisbrunnr.Server.Endpoints.Socials;

public class DeleteSocial(ISocialService socialService) : EndpointWithoutRequest<Result<SocialResponse.DeleteSocial>>
{
    public override void Configure()
    {
        Delete("/api/socials/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<SocialResponse.DeleteSocial>> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return socialService.DeleteSocial(id, ct);
    }
}