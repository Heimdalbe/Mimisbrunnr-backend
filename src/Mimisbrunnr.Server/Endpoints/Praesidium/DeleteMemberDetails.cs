using Mimisbrunnr.Shared.Praesidium;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class DeleteMemberDetails(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.DeleteMemberDetails>>
{
    public override void Configure()
    {
        Delete("/api/praesidium/memberdetails/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.DeleteMemberDetails>> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.DeleteMemberDetails(id, ct);
    }
}