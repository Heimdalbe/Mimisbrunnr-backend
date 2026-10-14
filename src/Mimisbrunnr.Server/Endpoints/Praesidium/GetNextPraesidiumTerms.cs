using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetNextPraesidiumTerms(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.GetNextPraesidiumTerms>>
{
    public override void Configure()
    {
        Get("/api/praesidium/members/next/{id:int}");
        AllowAnonymous();
    }

    public override Task<Result<PraesidiumResponse.GetNextPraesidiumTerms>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        return praesidiumService.GetNextPraesidiumTerms(id, ct);
    }
}