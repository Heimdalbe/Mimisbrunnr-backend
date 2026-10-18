using Mimisbrunnr.Shared.Sponsors;

namespace Mimisbrunnr.Server.Endpoints.Sponsors;

public class GetSponsorsForSponsorPage(ISponsorService sponsorService) : EndpointWithoutRequest<Result<SponsorResponse.GetSponsorsForSponsorPage>>
{
    public override void Configure()
    {
        Get("/api/sponsors/sponsorpage");
        AllowAnonymous();
    }

    public override Task<Result<SponsorResponse.GetSponsorsForSponsorPage>> ExecuteAsync(CancellationToken ct)
    {
        return sponsorService.GetSponsorsForSponsorPage(ct);
    }
}