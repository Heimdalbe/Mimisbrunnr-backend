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
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Quote { get; set; }
        public string? Trivia { get; set; }

        public string? ImageUrl { get; set; }
        
        public class Validator : AbstractValidator<PostErelid>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotNull().NotEmpty();
                RuleFor(x => x.LastName).NotNull().NotEmpty();
                RuleFor(x => x.Quote).NotNull();
                RuleFor(x => x.Trivia).NotNull();
                RuleFor(x => x.ImageUrl).NotNull().NotEmpty();
            }
        }
    }
}