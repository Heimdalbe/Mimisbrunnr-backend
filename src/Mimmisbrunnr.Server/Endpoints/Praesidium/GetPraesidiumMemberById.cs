using Mimmisbrunnr.Shared.Praesidium;
using Mimmisbrunnr.Shared.Praesidium.Dtos;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class GetPraesidiumMemberById(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumTermDto.Detailed>>
{
    public override void Configure()
    {
        Get("api/praesidium/members/{id:int}");
    }

    public override Task<Result<PraesidiumTermDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("int");
        return praesidiumService.GetPraesidiumTermDetailed(id, ct);
    }
}