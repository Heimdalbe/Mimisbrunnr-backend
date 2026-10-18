using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetAllPraesidiumTerms(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.GetAllPraesidiumTerms>>
{
    public override void Configure()
    {
        Get("/api/praesidium/members/terms/{id:int}");
        AllowAnonymous();
    }

    public override Task<Result<PraesidiumResponse.GetAllPraesidiumTerms>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        return praesidiumService.GetAllPraesidiumTerms(id, ct);
    }
}