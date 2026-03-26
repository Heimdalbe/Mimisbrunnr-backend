using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class GetErelids(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.GetErelids>>
{
    public override void Configure()
    {
        Get("api/praesidium/erelids");
    }

    public override Task<Result<PraesidiumResponse.GetErelids>> ExecuteAsync(CancellationToken ct)
    {
        return praesidiumService.GetErelids(ct);
    }
}