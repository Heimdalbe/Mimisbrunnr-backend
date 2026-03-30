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
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Quote { get; set; }
        public string? Trivia { get; set; }
        public int? Year { get; set; }
        
        public int? Role {get; set;}

        public string? ImageUrl { get; set; }
        
        public class Validator : AbstractValidator<PutPraesidiumMember>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotEmpty().When(x => x.FirstName != null);
                RuleFor(x => x.LastName).NotEmpty().When(x => x.LastName != null);
                RuleFor(x => x.Year).GreaterThanOrEqualTo(2018).When(x => x.Year.HasValue);
                RuleFor(x => x.Role).GreaterThan(0).When(x => x.Role != null);
                RuleFor(x => x.ImageUrl).NotEmpty().When(x => x.ImageUrl != null);
            }
        }
    }
}