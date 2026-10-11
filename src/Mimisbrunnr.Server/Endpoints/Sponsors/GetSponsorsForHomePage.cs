using Mimisbrunnr.Shared.Sponsors;

namespace Mimisbrunnr.Server.Endpoints.Sponsors;

public class GetSponsorsForHomePage(ISponsorService sponsorService) : EndpointWithoutRequest<Result<SponsorResponse.GetSponsorsForHomePage>>
{
    public override void Configure()
    {
        Get("/api/sponsors/homepage");
        AllowAnonymous();
    }

    public override Task<Result<SponsorResponse.GetSponsorsForHomePage>> ExecuteAsync(CancellationToken ct)
    {
        return sponsorService.GetSponsorsForHomePage(ct);
    }
}