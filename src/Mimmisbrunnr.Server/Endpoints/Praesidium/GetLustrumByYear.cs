using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class GetLustrumByYear(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.GetLustrumLids>>
{
    public override void Configure()
    {
        Get("/api/praesidium/lustrum/{year:int}");
    }

    public override Task<Result<PraesidiumResponse.GetLustrumLids>> ExecuteAsync(CancellationToken ct)
    {
        var year = Route<int>("year");
        return praesidiumService.GetLustrumLids(year,ct);
    }
}