namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class PostLustrumLid
    {
        public required int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class PostLustrumLid
    {
        public required int MemberId { get; set; }

        public int Year { get; set; }
        
        public string? ImageUrl { get; set; }
        
        public class Validator : AbstractValidator<PostLustrumLid>
        {
            public Validator()
            {
                RuleFor(x => x.MemberId).NotNull().GreaterThan(0);
                RuleFor(x => x.Year).NotNull().GreaterThanOrEqualTo(2023);
                RuleFor(x => x.ImageUrl).NotNull().NotEmpty();
            }
        }
    }
}