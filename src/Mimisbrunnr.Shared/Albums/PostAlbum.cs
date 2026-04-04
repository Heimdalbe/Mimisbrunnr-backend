namespace Mimisbrunnr.Shared.Albums;

public partial class AlbumResponse
{
    public class PostAlbum
    {
        public required int Id { get; set; }
    }
}

public partial class AlbumRequest
{
    public class PostAlbum
    {
        public required string Name { get; set; }
        public required int Year { get; set; }
        public string? CoverImageUrl { get; set; }
        public required string Description { get; set; } 
        public required bool Published { get; set; }
        
        public class Validator : AbstractValidator<PostAlbum>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotNull().NotEmpty();
                RuleFor(x => x.Year).NotNull().GreaterThanOrEqualTo(2018);
                RuleFor(x => x.CoverImageUrl).NotEmpty().When(x => x.CoverImageUrl is not null);
                RuleFor(x => x.Description).NotNull();
                RuleFor(x => x.Published).NotNull();
            }
        }
    }
}