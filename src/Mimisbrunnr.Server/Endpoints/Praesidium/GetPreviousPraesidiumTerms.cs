using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetPreviousPraesidiumTerms(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.GetPreviousPraesidiumTerms>>
{
    public override void Configure()
    {
        Get("/api/praesidium/members/previous/{id:int}");
        AllowAnonymous();
    }

    public override Task<Result<PraesidiumResponse.GetPreviousPraesidiumTerms>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        return praesidiumService.GetPreviousPraesidiumTerms(id, ct);
    }
}