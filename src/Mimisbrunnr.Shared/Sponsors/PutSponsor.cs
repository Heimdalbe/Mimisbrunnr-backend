namespace Mimisbrunnr.Shared.Sponsors;

public partial class SponsorResponse
{
    public class PutSponsor
    {
        public required int Id { get; set; }
    }
}

public partial class SponsorRequest
{
    public class PutSponsor
    {
        public string? Name { get; set; }

        public required string? LogoUrl { get; set; }

        public required string? Website { get; set; }

        public required string? Benefits { get; set; }

        public required string? SponsorRank { get; set; }
        
        public required string? LanSponsorRank { get; set; }
        
        public required int? Order { get; set; }

        class Validator :  AbstractValidator<PutSponsor>
        {
            Validator()
            {
                RuleFor(x => x.Name).NotEmpty().When(x => x.Name is not null);
                
                RuleFor(x => x.LogoUrl).NotEmpty().When(x => x.LogoUrl is not null);
                
                RuleFor(x => x.Website).NotEmpty().When(x => x.Website is not null);

                RuleFor(x => x.Benefits);
                
                RuleFor(x => x.SponsorRank).NotEmpty().When(x => x.SponsorRank is not null);
                
                RuleFor(x => x.LanSponsorRank).NotEmpty().When(x => x.LanSponsorRank is not null);
                
                RuleFor(x => x.Order).GreaterThanOrEqualTo(0).When(x => x.Order is not null);
            }
        }
    }
}