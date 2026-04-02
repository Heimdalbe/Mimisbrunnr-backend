namespace Mimisbrunnr.Shared.Albums;

public partial class AlbumResponse
{
    public class PutAlbum
    {
        public required int Id { get; set; }
    }
}

public partial class AlbumRequest
{
    public class PutAlbum
    {
        public string? Name { get; set; }
        public int? Year { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? Description { get; set; } 
        public bool? Published { get; set; }
        
        public class Validator : AbstractValidator<PutAlbum>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty().When(x => x.Name is not null);
                RuleFor(x => x.Year).GreaterThanOrEqualTo(2018).When(x => x.Year is not null);
                RuleFor(x => x.CoverImageUrl).NotEmpty().When(x => x.CoverImageUrl is not null);
                RuleFor(x => x.Description);
                RuleFor(x => x.Published);
            }
        }
    }
}