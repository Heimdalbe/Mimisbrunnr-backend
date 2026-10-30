using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Domain.Membership;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Shared.Membership;

namespace Mimisbrunnr.Services.Membership;

public class MembershipFeesService(ApplicationDbContext db, ISessionContextProvider session) : IMembershipFeesService
{
    public async Task<Result<MembershipFeesDto>> Get(CancellationToken ct) =>
        Result.Success(ToDto(await db.MembershipFees.AsNoTracking().SingleAsync(f => f.Id == 1, ct)));

    public async Task<Result<MembershipFeesDto>> Update(UpdateMembershipFees request, CancellationToken ct)
    {
        if (session.User?.IsInRole(AppRoles.Hmdl) != true)
            return Result.Forbidden();

        var validation = await new UpdateMembershipFees.Validator().ValidateAsync(request, ct);
        if (!validation.IsValid)
            return Result.Invalid(validation.Errors.Select(e => new ValidationError(e.PropertyName, e.ErrorMessage)));

        var fees = await db.MembershipFees.SingleAsync(f => f.Id == 1, ct);
        fees.FirstYearFee = request.FirstYearFee!.Value;
        fees.RenewalFee = request.RenewalFee!.Value;
        await db.SaveChangesAsync(ct);
        return Result.Success(ToDto(fees));
    }

    private static MembershipFeesDto ToDto(MembershipFees fees) => new()
    {
        FirstYearFee = fees.FirstYearFee,
        RenewalFee = fees.RenewalFee
    };
}
