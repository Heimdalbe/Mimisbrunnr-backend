namespace Mimisbrunnr.Shared.Socials;

public partial class SocialResponse
{
    public class PostSocialType
    {
        public required int Id { get; set; }
    }
}

public partial class SocialRequest
{
    public class PostSocialType
    {
        public required string IconUrl { get; set; }
        
        public required string Name { get; set; }
        
        public class Validator :  AbstractValidator<PostSocialType>
        {
            public Validator()
            {
                RuleFor(x => x.IconUrl).NotNull().NotEmpty();
                RuleFor(x => x.Name).NotNull().NotEmpty();
            }
        }
    }
}