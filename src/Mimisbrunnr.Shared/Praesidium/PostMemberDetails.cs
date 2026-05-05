namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class PostMemberDetails
    {
        public required int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class PostMemberDetails
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Quote { get; set; }
        public required string Trivia { get; set; }
        
        public class Validator : AbstractValidator<PostMemberDetails>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotNull().NotEmpty();
                RuleFor(x => x.LastName).NotNull().NotEmpty();
                RuleFor(x => x.Quote).NotNull();
                RuleFor(x => x.Trivia).NotNull();
            }
        }
    }
}