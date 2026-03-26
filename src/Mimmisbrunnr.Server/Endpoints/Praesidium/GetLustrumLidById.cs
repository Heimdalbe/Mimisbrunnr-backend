using Mimmisbrunnr.Shared.Praesidium;
using Mimmisbrunnr.Shared.Praesidium.Dtos;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class GetLustrumLidById(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<LustrumLidDto.Detailed>>
{
    public override void Configure()
    {
        Get("api/praesidium/lustrum/members/{id:int}");
    }

    public override Task<Result<LustrumLidDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("int");
        return praesidiumService.GetLustrumlidDetailed(id, ct);
    }
}