using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class PutMemberDetails(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PutMemberDetails, Result<PraesidiumResponse.PutMemberDetails>>
{
    public override void Configure()
    {
        Put("/api/praesidium/memberdetails/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.PutMemberDetails>> ExecuteAsync(PraesidiumRequest.PutMemberDetails req, CancellationToken ct)
    {
        var id = Route<int>("id");
        return praesidiumService.PutMemberDetails(id, req, ct);
    }
}