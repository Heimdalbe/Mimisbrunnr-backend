using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetLustrumYears(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.GetYears>>
{
    public override void Configure()
    {
        Get("/api/praesidium/years");
    }

    public override Task<Result<PraesidiumResponse.GetYears>> ExecuteAsync(CancellationToken ct)
    {
        return praesidiumService.GetLustrumYears(ct);
    }
}