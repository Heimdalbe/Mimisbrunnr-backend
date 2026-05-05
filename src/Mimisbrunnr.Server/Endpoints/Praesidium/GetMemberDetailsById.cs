using Mimisbrunnr.Shared.Praesidium;
using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Server.Endpoints.Praesidium;

public class GetMemberDetailsById(IPraesidiumService praesidiumService) : EndpointWithoutRequest<Result<MemberDetailsDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/praesidium/memberdetails/{id:int}");
        AllowAnonymous();
    }

    public override Task<Result<MemberDetailsDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        return praesidiumService.GetMemberDetailsDetailed(id, ct);
    }
}