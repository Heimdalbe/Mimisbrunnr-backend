namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class PostErelid
    {
        public required int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class PostErelid
    {
        public required int MemberId { get; set; }
        
        public string? ImageUrl { get; set; }
        
        public class Validator : AbstractValidator<PostErelid>
        {
            public Validator()
            {
                RuleFor(x => x.MemberId).NotNull().GreaterThan(0);
                RuleFor(x => x.ImageUrl).NotNull().NotEmpty();
            }
        }
    }
}