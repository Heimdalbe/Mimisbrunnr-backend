using Mimmisbrunnr.Shared.Identity;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class PutErelid(IPraesidiumService praesidiumService) : Endpoint<PraesidiumRequest.PutErelid, PraesidiumResponse.PutErelid>
{
    public override void Configure()
    {
        Post("/api/praesidium/erelids/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<PraesidiumResponse.PutErelid> ExecuteAsync(PraesidiumRequest.PutErelid req, CancellationToken ct)
    {
        var id = Route<int>("id");
        return praesidiumService.PutErelid(id, req, ct);
    }
}