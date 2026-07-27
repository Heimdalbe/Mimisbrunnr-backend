namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class PutErelid
    {
        public required int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class PutErelid
    {
        public int? MemberId { get; set; }

        public string? ImageUrl { get; set; }
        
        public class Validator : AbstractValidator<PutErelid>
        {
            public Validator()
            {
                RuleFor(x => x.MemberId).GreaterThan(0).When(x => x.MemberId.HasValue);
                RuleFor(x => x.ImageUrl).NotEmpty().When(x => x.ImageUrl != null);
            }
        }
    }
}