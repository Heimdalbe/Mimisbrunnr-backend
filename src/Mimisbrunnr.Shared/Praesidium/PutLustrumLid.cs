namespace Mimisbrunnr.Shared.Praesidium;

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
        public int? MemberId { get; set; }

        public int? Year { get; set; }
        
        public string? ImageUrl { get; set; }
        
        public class Validator : AbstractValidator<PutLustrumLid>
        {
            public Validator()
            {
                RuleFor(x => x.MemberId).GreaterThan(0).When(x => x.MemberId.HasValue);
                RuleFor(x => x.Year).GreaterThanOrEqualTo(2023).When(x => x.Year.HasValue);
                RuleFor(x => x.ImageUrl).NotEmpty().When(x => x.ImageUrl != null);
            }
        }
    }
}