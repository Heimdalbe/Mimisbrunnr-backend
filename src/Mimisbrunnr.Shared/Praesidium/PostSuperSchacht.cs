namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class PostSuperSchacht
    {
        public required int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class PostSuperSchacht
    {
        public required int MemberId { get; set; }
        
        public int Year { get; set; }

        public string? ImageUrl { get; set; }
        
        public class Validator : AbstractValidator<PostSuperSchacht>
        {
            public Validator()
            {
                RuleFor(x => x.MemberId).NotNull().GreaterThan(0);
                RuleFor(x => x.Year).NotNull().GreaterThan(2018);
                RuleFor(x => x.ImageUrl).NotNull().NotEmpty();
            }
        }
    }
}