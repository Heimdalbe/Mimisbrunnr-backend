namespace Mimisbrunnr.Shared.Membership;

public interface IMembershipFeesService
{
    Task<Result<MembershipFeesDto>> Get(CancellationToken ct);
    Task<Result<MembershipFeesDto>> Update(UpdateMembershipFees request, CancellationToken ct);
}
