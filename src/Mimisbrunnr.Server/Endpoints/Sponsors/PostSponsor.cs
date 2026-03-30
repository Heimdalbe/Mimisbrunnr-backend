using Mimisbrunnr.Shared.Sponsors;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Sponsors;

public class PostSponsor(ISponsorService sponsorService) : Endpoint<SponsorRequest.PostSponsor, Result<SponsorResponse.PostSponsor>>
{
    public override void Configure()
    {
        Post("/api/sponsors");
        Roles(AppRoles.SponsorEditor, AppRoles.Hmdl);
    }

    public override Task<Result<SponsorResponse.PostSponsor>> ExecuteAsync(SponsorRequest.PostSponsor req, CancellationToken ct)
    {
        return sponsorService.PostSponsor(req, ct);
    }
}