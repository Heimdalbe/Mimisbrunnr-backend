using Mimisbrunnr.Shared.Praesidium;
using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetPraesidiumMemberById(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumTermDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/praesidium/members/{id:int}");
    }

    public override Task<Result<PraesidiumTermDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        return praesidiumService.GetPraesidiumTermDetailed(id, ct);
    }
}