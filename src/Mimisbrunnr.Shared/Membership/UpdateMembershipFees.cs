namespace Mimisbrunnr.Shared.Membership;

public class UpdateMembershipFees
{
    public decimal? FirstYearFee { get; set; }
    public decimal? RenewalFee { get; set; }

    public class Validator : AbstractValidator<UpdateMembershipFees>
    {
        public Validator()
        {
            RuleFor(f => f.FirstYearFee).NotNull().InclusiveBetween(0m, 9999.99m).PrecisionScale(6, 2, true);
            RuleFor(f => f.RenewalFee).NotNull().InclusiveBetween(0m, 9999.99m).PrecisionScale(6, 2, true);
        }
    }
}
