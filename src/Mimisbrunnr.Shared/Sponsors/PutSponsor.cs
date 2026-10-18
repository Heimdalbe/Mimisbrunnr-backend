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

        public string? LogoUrl { get; set; }

        public string? Website { get; set; }

        public string? Benefits { get; set; }
        
        public string? Description { get; set; }

        public string? SponsorRank { get; set; }
        
        public string? LanSponsorRank { get; set; }
        
        public int? Order { get; set; }
        
        public bool? OnHomePage { get; set; }
        
        public bool? OnSponsorPage { get; set; }

        public class Validator :  AbstractValidator<PutSponsor>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty().When(x => x.Name is not null);
                
                RuleFor(x => x.LogoUrl).NotEmpty().When(x => x.LogoUrl is not null);
                
                RuleFor(x => x.Website).NotEmpty().When(x => x.Website is not null);

                RuleFor(x => x.Benefits);
                
                RuleFor(x => x.Description);
                
                RuleFor(x => x.SponsorRank).NotEmpty().When(x => x.SponsorRank is not null);
                
                RuleFor(x => x.LanSponsorRank).NotEmpty().When(x => x.LanSponsorRank is not null);
                
                RuleFor(x => x.Order).GreaterThanOrEqualTo(0).When(x => x.Order is not null);
                
                RuleFor(x => x.OnHomePage).NotEmpty().When(x => x.OnHomePage is not null);
                
                RuleFor(x => x.OnSponsorPage).NotEmpty().When(x => x.OnSponsorPage is not null);
            }
        }
    }
}