namespace Mimisbrunnr.Shared.Sponsors;

public partial class SponsorResponse
{
    public class PostSponsor
    {
        public required int Id { get; set; }
    }
}

public partial class SponsorRequest
{
    public class PostSponsor
    {
        public required string Name { get; set; }

        public required string LogoUrl { get; set; }

        public required string Website { get; set; }

        public required string Benefits { get; set; }

        public required string? SponsorRank { get; set; }
        
        public required string? LanSponsorRank { get; set; }
        
        public required int Order { get; set; }

        class Validator :  AbstractValidator<PostSponsor>
        {
            Validator()
            {
                RuleFor(x => x.Name).NotNull().NotEmpty();
                
                RuleFor(x => x.LogoUrl).NotNull().NotEmpty();
                
                RuleFor(x => x.Website).NotNull().NotEmpty();

                RuleFor(x => x.Benefits).NotNull();
                
                RuleFor(x => x.SponsorRank).NotNull();
                RuleFor(x => x.SponsorRank).NotEmpty().When(x => x.SponsorRank is not null);
                
                RuleFor(x => x.LanSponsorRank).NotNull();
                RuleFor(x => x.LanSponsorRank).NotEmpty().When(x => x.LanSponsorRank is not null);
                
                RuleFor(x => x.Order).NotNull().GreaterThanOrEqualTo(0);
            }
        }
    }
}