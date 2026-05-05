namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class PutPraesidiumMember
    {
        public required int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class PutPraesidiumMember
    {
        public int? MemberId { get; set; }
        public int? Year { get; set; }
        
        public int? Role {get; set;}

        public string? ImageUrl { get; set; }
        
        public class Validator : AbstractValidator<PutPraesidiumMember>
        {
            public Validator()
            {
                RuleFor(x => x.MemberId).GreaterThan(0).When(x => x.MemberId.HasValue);
                RuleFor(x => x.Year).GreaterThanOrEqualTo(2018).When(x => x.Year.HasValue);
                RuleFor(x => x.Role).GreaterThan(0).When(x => x.Role.HasValue);
                RuleFor(x => x.ImageUrl).NotEmpty().When(x => x.ImageUrl != null);
            }
        }
    }
}