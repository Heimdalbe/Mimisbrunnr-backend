using Mimmisbrunnr.Shared.Praesidium;
using Mimmisbrunnr.Shared.Praesidium.Dtos;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class GetSuperSchachtById(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<SuperSchachtDto.Detailed>>
{
    public override void Configure()
    {
        Get("api/praesidium/superschachts/{id:int}");
    }

    public override Task<Result<SuperSchachtDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("int");
        return praesidiumService.GetSuperschachtDetailed(id, ct);
    }
}