namespace Mimisbrunnr.Shared.Socials;

public partial class SocialResponse
{
    public class PutSocial
    {
        public required int Id { get; set; }
    }
}

public partial class SocialRequest
{
    public class PutSocial
    {
        public int? TypeId { get; set; }
        
        public string? Url { get; set; }
        
        public class Validator :  AbstractValidator<PutSocial>
        {
            public Validator()
            {
                RuleFor(x => x.TypeId).GreaterThan(0).When(x => x.TypeId is not null);
                RuleFor(x => x.Url).NotEmpty().When(x => x.Url is not null);
            }
        }
    }
}