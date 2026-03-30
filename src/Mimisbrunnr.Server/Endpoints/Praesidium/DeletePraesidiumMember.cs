using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class DeletePraesidiumMember(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.DeletePraesidiumMember>>
{
    public override void Configure()
    {
        Delete("/api/praesidium/members/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.DeletePraesidiumMember>> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.DeletePraesidiumMember(id, ct);
    }
}