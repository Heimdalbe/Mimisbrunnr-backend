namespace Mimisbrunnr.Shared.Events;

public partial class EventResponse
{
    public class PostEvent
    {
        public int Id { get;set; }
    }
}

public partial class EventRequest{

    public class PostEvent
    {
        
        public required string Category { get; set; }

        public required string  Accessibility { get; set; }

        public required string Name { get; set; }

        public required string? Location { get;set; }

        public required DateTime? Start { get; set; }

        public required DateTime? End { get; set; }

        public required string? Description { get; set; }

        public required string? ICal { get; set; }

        public required string? BannerUrl { get; set; }

        public required int[]? SponsorIds { get; set; }

        public required string? EntryFee { get; set; }

        public required bool Published { get; set; }

        public class Validator : AbstractValidator<PostEvent>
        {
            public Validator()
            {
                RuleFor(x => x.Category).NotNull().NotEmpty();
                
                RuleFor(x => x.Accessibility).NotNull().NotEmpty();
                
                RuleFor(x => x.Name).NotNull().NotEmpty();
                
                RuleFor(x => x.Location).NotNull().When(x => x.Published);
                RuleFor(x => x.Location).NotEmpty().When(x => x.Location is not null);
                
                RuleFor(x => x.Start).NotNull().When(x => x.Published);
                
                RuleFor(x => x.End).NotNull().When(x => x.Published);
                
                RuleFor(x => x.Description).NotNull().When(x => x.Published);
                RuleFor(x => x.Description).NotEmpty().When(x => x.Description is not null);
                
                RuleFor(x => x.ICal).NotNull().When(x => x.Published);
                
                RuleFor(x => x.BannerUrl).NotNull().When(x => x.Published);
                RuleFor(x => x.BannerUrl).NotEmpty().When(x => x.BannerUrl is not null);
                
                RuleFor(x => x.SponsorIds).NotNull().When(x => x.Published);
                
                RuleFor(x =>  x.EntryFee).NotNull().When(x => x.Published);
            }
        }
    }
}