using Mimisbrunnr.Shared.Sponsors;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Sponsors;

public class PutSponsor(ISponsorService sponsorService) : Endpoint<SponsorRequest.PutSponsor, Result<SponsorResponse.PutSponsor>>
{
    public override void Configure()
    {
        Post("/api/sponsors/{id:int}");
        Roles(AppRoles.SponsorEditor, AppRoles.Hmdl);
    }

    public override Task<Result<SponsorResponse.PutSponsor>> ExecuteAsync(SponsorRequest.PutSponsor req, CancellationToken ct)
    {
        var id = Route<int>("id");
        return sponsorService.PutSponsor(id, req, ct);
    }
}