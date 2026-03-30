using Mimisbrunnr.Shared.Sponsors.Dtos;

namespace Mimisbrunnr.Shared.Sponsors;

public interface ISponsorService
{
    Task<Result<SponsorResponse.GetSponsors>> GetSponsors(CancellationToken cancellationToken = default);

    Task<Result<SponsorDto.Detailed>> GetSponsor(int id, CancellationToken cancellationToken = default);

    Task<Result<SponsorResponse.PostSponsor>> PostSponsor(SponsorRequest.PostSponsor req, CancellationToken cancellationToken = default);

    Task<Result<SponsorResponse.PutSponsor>> PutSponsor(int id, SponsorRequest.PutSponsor req, CancellationToken cancellationToken = default);

    Task<Result<SponsorResponse.DeleteSponsor>> DeleteSponsor(int id, CancellationToken cancellationToken = default);
}