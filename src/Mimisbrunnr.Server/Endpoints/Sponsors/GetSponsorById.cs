using Mimisbrunnr.Shared.Sponsors;
using Mimisbrunnr.Shared.Sponsors.Dtos;

namespace Mimisbrunnr.Server.Endpoints.Sponsors;

public class GetSponsorById(ISponsorService sponsorService) : EndpointWithoutRequest<Result<SponsorDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/sponsors/{id:int}");
    }

    public override Task<Result<SponsorDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        return sponsorService.GetSponsor(id, ct);
    }
}