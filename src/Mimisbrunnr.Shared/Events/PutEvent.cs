namespace Mimisbrunnr.Shared.Events;

public partial class EventResponse
{
    public class PutEvent
    {
        public int Id { get;set; }
    }
}

public partial class EventRequest{

    public class PutEvent
    {
        
        public string? Category { get; set; }

        public string?  Accessibility { get; set; }

        public string? Name { get; set; }

        public string? Location { get;set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public string? Description { get; set; }

        public string? ICal { get; set; }

        public string? BannerUrl { get; set; }

        public int[]? SponsorIds { get; set; }

        public string? EntryFee { get; set; }

        public bool? Published { get; set; }

        public class Validator : AbstractValidator<PutEvent>
        {
            public Validator()
            {
                RuleFor(x => x.Category).NotEmpty().When(x => x.Category is not null);
                
                RuleFor(x => x.Accessibility).NotEmpty().When(x => x.Accessibility is not null);
                
                RuleFor(x => x.Name).NotEmpty().When(x => x.Name is not null);
                
                RuleFor(x => x.Location).NotEmpty().When(x => x.Location is not null);
                
                RuleFor(x => x.Description).NotEmpty().When(x => x.Location is not null);
                
                RuleFor(x => x.BannerUrl).NotEmpty().When(x => x.Location is not null);
                
                RuleFor(x => x.SponsorIds).NotEmpty().When(x => x.SponsorIds is not null);
            }
        }
    }
}