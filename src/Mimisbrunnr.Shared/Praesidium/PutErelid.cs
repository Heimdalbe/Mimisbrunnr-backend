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
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Quote { get; set; }
        public string? Trivia { get; set; }

        public string? ImageUrl { get; set; }
        
        public class Validator : AbstractValidator<PutErelid>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotEmpty().When(x => x.FirstName != null);
                RuleFor(x => x.LastName).NotEmpty().When(x => x.LastName != null);
                RuleFor(x => x.ImageUrl).NotEmpty().When(x => x.ImageUrl != null);
            }
        }
    }
}