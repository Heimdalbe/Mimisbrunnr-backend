using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class PutPraesidiumMember(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PutPraesidiumMember, PraesidiumResponse.PutPraesidiumMember>
{
    public override void Configure()
    {
        Put("/api/praesidium/members/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.PutPraesidiumMember> ExecuteAsync(PraesidiumRequest.PutPraesidiumMember req, CancellationToken ct)
    {
        var id = Route<int>("id");
        return praesidiumService.PutPraesidiumMember(id, req, ct);
    }
}