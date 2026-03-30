using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetPraesidiumByYear(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.GetPraesidiumOfYear>>
{
    public override void Configure()
    {
        Get("/api/praesidium/{year:int}");
    }

    public override Task<Result<PraesidiumResponse.GetPraesidiumOfYear>> ExecuteAsync(CancellationToken ct)
    {
        var year = Route<int>("year");
        return praesidiumService.GetPraesidiumOfYear(year, ct);
    }
}