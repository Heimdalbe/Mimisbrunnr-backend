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
        public string? Name { get; set; }
        
        public string? Email { get; set; }
        
        public int Order { get; set; }
        
        public class Validator : AbstractValidator<PostPraesidiumRole>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotNull().NotEmpty();
                RuleFor(x => x.Email).NotNull().NotEmpty();
                RuleFor(x => x.Order).NotNull().GreaterThanOrEqualTo(0);
            }
        }
    }
}