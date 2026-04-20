using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetLustrumByYear(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.GetLustrumLids>>
{
    public override void Configure()
    {
        Get("/api/praesidium/lustrum/{year:int}");
        AllowAnonymous();
    }

    public override Task<Result<PraesidiumResponse.GetLustrumLids>> ExecuteAsync(CancellationToken ct)
    {
        var year = Route<int>("year");
        return praesidiumService.GetLustrumLids(year,ct);
    }
}