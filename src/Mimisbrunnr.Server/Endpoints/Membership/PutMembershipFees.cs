using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Membership;

namespace Mimisbrunnr.Server.Endpoints.Membership;

public class PutMembershipFees(IMembershipFeesService service) : Endpoint<UpdateMembershipFees, Result<MembershipFeesDto>>
{
    public override void Configure()
    {
        Put("/api/membership-fees");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<MembershipFeesDto>> ExecuteAsync(UpdateMembershipFees req, CancellationToken ct) =>
        service.Update(req, ct);
}
