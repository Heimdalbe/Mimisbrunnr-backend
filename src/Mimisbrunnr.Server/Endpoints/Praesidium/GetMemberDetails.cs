using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetMemberDetails(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<PraesidiumResponse.GetMemberDetails>>
{
    public override void Configure()
    {
        Get("/api/praesidium/memberdetails");
        AllowAnonymous();
    }

    public override Task<Result<PraesidiumResponse.GetMemberDetails>> ExecuteAsync(CancellationToken ct)
    {
        return praesidiumService.GetMemberDetails(ct);
    }
}