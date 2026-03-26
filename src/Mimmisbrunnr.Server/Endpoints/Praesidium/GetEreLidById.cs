using Mimmisbrunnr.Shared.Praesidium;
using Mimmisbrunnr.Shared.Praesidium.Dtos;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class GetEreLidById(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<ErelidDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/praesidium/erelids/{id:int}");
    }

    public override Task<Result<ErelidDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("int");
        return praesidiumService.GetErelidDetailed(id, ct);
    }
}