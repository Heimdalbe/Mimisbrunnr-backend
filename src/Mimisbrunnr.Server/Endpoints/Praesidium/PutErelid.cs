using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class PutErelid(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PutErelid, Result<PraesidiumResponse.PutErelid>>
{
    public override void Configure()
    {
        Post("/api/praesidium/erelids/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<PraesidiumResponse.PutErelid>> ExecuteAsync(PraesidiumRequest.PutErelid req, CancellationToken ct)
    {
        var id = Route<int>("id");
        return praesidiumService.PutErelid(id, req, ct);
    }
}