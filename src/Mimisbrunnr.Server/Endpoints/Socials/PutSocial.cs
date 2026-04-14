using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Socials;

namespace Mimisbrunnr.Server.Endpoints.Socials;

public class PutSocial(ISocialService socialService) : Endpoint<SocialRequest.PutSocial, Result<SocialResponse.PutSocial>>
{
    public override void Configure()
    {
        Put("/api/socials/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<SocialResponse.PutSocial>> ExecuteAsync(SocialRequest.PutSocial req, CancellationToken ct)
    {
        int id = Route<int>("id");
        return socialService.PutSocial(id, req, ct);
    }
}