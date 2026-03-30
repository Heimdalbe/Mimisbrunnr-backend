using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class PutPraesidiumMember(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PutPraesidiumMember, Result<PraesidiumResponse.PutPraesidiumMember>>
{
    public override void Configure()
    {
        Put("/api/praesidium/members/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.PutPraesidiumMember>> ExecuteAsync(PraesidiumRequest.PutPraesidiumMember req, CancellationToken ct)
    {
        var id = Route<int>("id");
        return praesidiumService.PutPraesidiumMember(id, req, ct);
    }
}