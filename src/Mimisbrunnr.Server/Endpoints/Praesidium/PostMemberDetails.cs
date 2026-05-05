using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class PostMemberDetails(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PostMemberDetails, Result<PraesidiumResponse.PostMemberDetails>>
{
    public override void Configure()
    {
        Post("/api/praesidium/memberdetails");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.PostMemberDetails>> ExecuteAsync(PraesidiumRequest.PostMemberDetails req, CancellationToken ct)
    {
        return praesidiumService.PostMemberDetails(req, ct);
    }
}