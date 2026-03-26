namespace Mimmisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class PutPraesidiumRole
    {
        public int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class PutPraesidiumRole
    {
        public string? Name { get; set; }
        
        public string? Email { get; set; }
        
        public int? Order { get; set; }
        
        public class Validator : AbstractValidator<PutPraesidiumRole>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty().When(x => x.Name != null);
                RuleFor(x => x.Email).NotEmpty().When(x => x.Email != null);
                RuleFor(x => x.Order).GreaterThanOrEqualTo(0).When(x => x.Order.HasValue);
            }
        }
    }
}