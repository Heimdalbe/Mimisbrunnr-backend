namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class PutMemberDetails
    {
        public required int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class PutMemberDetails
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Quote { get; set; }
        public string? Trivia { get; set; }

        public class Validator : AbstractValidator<PutMemberDetails>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotEmpty().When(x => x.Quote is not null);
                RuleFor(x => x.LastName).NotEmpty().When(x => x.Quote is not null);
            }
        }
    }
}