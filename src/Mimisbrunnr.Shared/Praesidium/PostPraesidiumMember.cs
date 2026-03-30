namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class PostPraesidiumMember
    {
        public required int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class PostPraesidiumMember
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Quote { get; set; }
        public string? Trivia { get; set; }
        public int Year { get; set; }
        
        public int? Role {get; set;}

        public string? ImageUrl { get; set; }
        
        public class Validator : AbstractValidator<PostPraesidiumMember>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotNull().NotEmpty();
                RuleFor(x => x.LastName).NotNull().NotEmpty();
                RuleFor(x => x.Quote).NotNull();
                RuleFor(x => x.Trivia).NotNull();
                RuleFor(x => x.Year).NotNull().GreaterThanOrEqualTo(2018);
                RuleFor(x => x.Role).NotNull().GreaterThan(0);
                RuleFor(x => x.ImageUrl).NotNull().NotEmpty();
            }
        }
    }
}