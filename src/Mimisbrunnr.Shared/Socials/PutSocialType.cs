namespace Mimisbrunnr.Shared.Socials;

public partial class SocialResponse
{
    public class PutSocialType
    {
        public required int Id { get; set; }
    }
}

public partial class SocialRequest
{
    public class PutSocialType
    {
        public string? IconUrl { get; set; }
        
        public string? Name { get; set; }
        
        public class Validator :  AbstractValidator<PutSocialType>
        {
            public Validator()
            {
                RuleFor(x => x.IconUrl).NotEmpty().When(x => x.IconUrl is not null);
                RuleFor(x => x.Name).NotEmpty().When(x => x.Name is not null);
            }
        }
    }
}