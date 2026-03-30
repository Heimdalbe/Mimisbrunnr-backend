using Mimisbrunnr.Shared.Sponsors;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Sponsors;

public class DeleteSponsor(ISponsorService sponsorService) : EndpointWithoutRequest<Result<SponsorResponse.DeleteSponsor>>
{
    public override void Configure()
    {
        Delete("/api/sponsors/{id:int}");
        Roles(AppRoles.SponsorEditor, AppRoles.Hmdl);
    }

    public override Task<Result<SponsorResponse.DeleteSponsor>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        return sponsorService.DeleteSponsor(id, ct);
    }
}