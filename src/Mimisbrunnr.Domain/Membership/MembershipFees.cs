namespace Mimisbrunnr.Domain.Membership;

public class MembershipFees
{
    public int Id { get; set; } = 1;
    public decimal FirstYearFee { get; set; }
    public decimal RenewalFee { get; set; }
}
