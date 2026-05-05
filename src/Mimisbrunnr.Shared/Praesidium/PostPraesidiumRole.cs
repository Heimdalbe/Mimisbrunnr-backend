namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class PostPraesidiumRole
    {
        public int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class PostPraesidiumRole
    {
        public required string Name { get; set; }
        
        public required string Email { get; set; }
        
        public required int Order { get; set; }
        
        public class Validator : AbstractValidator<PostPraesidiumRole>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotNull().NotEmpty();
                RuleFor(x => x.Email).NotNull().EmailAddress();
                RuleFor(x => x.Order).NotNull().GreaterThanOrEqualTo(0);
            }
        }
    }
}