namespace Mimmisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class PutLustrumLid
    {
        public required int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class PutLustrumLid
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Quote { get; set; }
        public string? Trivia { get; set; }

        public int? Year { get; set; }
        
        public string? ImageUrl { get; set; }
        
        public class Validator : AbstractValidator<PutLustrumLid>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotEmpty().When(x => x.FirstName != null);
                RuleFor(x => x.LastName).NotEmpty().When(x => x.FirstName != null);
                RuleFor(x => x.Year).GreaterThanOrEqualTo(2023).When(x => x.Year.HasValue);
                RuleFor(x => x.ImageUrl).NotEmpty().When(x => x.FirstName != null);
            }
        }
    }
}