namespace Mimisbrunnr.Shared.Praesidium;

public partial class PraesidiumResponse
{
    public class PostPraesidiumMember
    {
        public required int Id { get; set; }
    }
}

public partial class PraesidiumRequest
{
    public class PostPraesidiumMember
    {
        public required int MemberId { get; set; }
        public required int Year { get; set; }
        
        public required int Role {get; set;}

        public required string ImageUrl { get; set; }
        
        public class Validator : AbstractValidator<PostPraesidiumMember>
        {
            public Validator()
            {
                RuleFor(x => x.MemberId).NotNull().GreaterThan(0);
                RuleFor(x => x.Year).NotNull().GreaterThanOrEqualTo(2018);
                RuleFor(x => x.Role).NotNull().GreaterThan(0);
                RuleFor(x => x.ImageUrl).NotNull().NotEmpty();
            }
        }
    }
}