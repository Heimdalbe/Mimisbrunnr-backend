namespace Mimisbrunnr.Shared.Socials;

public partial class SocialResponse
{
    public class PostSocial
    {
        public required int Id { get; set; }
    }
}

public partial class SocialRequest
{
    public class PostSocial
    {
        public required int TypeId { get; set; }
        
        public required string Url { get; set; }
        
        public class Validator :  AbstractValidator<PostSocial>
        {
            public Validator()
            {
                RuleFor(x => x.TypeId).NotNull().GreaterThan(0);
                RuleFor(x => x.Url).NotNull().NotEmpty();
            }
        }
    }
}