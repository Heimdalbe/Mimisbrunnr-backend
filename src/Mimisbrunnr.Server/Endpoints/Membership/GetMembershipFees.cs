using Mimisbrunnr.Shared.Membership;

namespace Mimisbrunnr.Server.Endpoints.Membership;

public class GetMembershipFees(IMembershipFeesService service) : EndpointWithoutRequest<Result<MembershipFeesDto>>
{
    public override void Configure()
    {
        Get("/api/membership-fees");
        AllowAnonymous();
    }

    public override Task<Result<MembershipFeesDto>> ExecuteAsync(CancellationToken ct) => service.Get(ct);
}
