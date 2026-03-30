using Mimisbrunnr.Shared.Praesidium;
using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetLustrumLidById(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<LustrumLidDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/praesidium/lustrum/members/{id:int}");
    }

    public override Task<Result<LustrumLidDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("int");
        return praesidiumService.GetLustrumlidDetailed(id, ct);
    }
}