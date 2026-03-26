namespace Mimmisbrunnr.Shared.Praesidium;

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
        public string? name { get; set; }
        
        public string? email { get; set; }
        
        public int order { get; set; }
        
        public class Validator : AbstractValidator<PostPraesidiumRole>
        {
            public Validator()
            {
                RuleFor(x => x.name).NotNull().NotEmpty();
                RuleFor(x => x.email).NotNull().NotEmpty();
                RuleFor(x => x.order).NotNull().GreaterThanOrEqualTo(0);
            }
        }
    }
}