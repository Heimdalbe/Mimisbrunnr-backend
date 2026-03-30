using Mimisbrunnr.Shared.Sponsors;

namespace Mimisbrunnr.Server.Endpoints.Sponsors;

public class GetSponsors(ISponsorService sponsorService) : EndpointWithoutRequest<Result<SponsorResponse.GetSponsors>>
{
    public override void Configure()
    {
        Get("/api/sponsors/");
    }

    public override Task<Result<SponsorResponse.GetSponsors>> ExecuteAsync(CancellationToken ct)
    {
        return sponsorService.GetSponsors(ct);
    }
}