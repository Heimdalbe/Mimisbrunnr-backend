using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Server.Endpoints.Praesidium;

public class GetSuperschachts(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.GetSuperSchachts>>
{
    public override void Configure()
    {
        Get("api/praesidium/superschachts");
    }

    public override Task<Result<PraesidiumResponse.GetSuperSchachts>> ExecuteAsync(CancellationToken ct)
    {
        return praesidiumService.GetSuperschachts(ct);
    }
}