using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class DeletePraesidiumMember(IPraesidiumService praesidiumService) : EndpointWithoutRequest<PraesidiumResponse.DeletePraesidiumMember>
{
    public override void Configure()
    {
        Delete("/api/praesidium/members/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.DeletePraesidiumMember> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return praesidiumService.DeletePraesidiumMember(id, ct);
    }
}