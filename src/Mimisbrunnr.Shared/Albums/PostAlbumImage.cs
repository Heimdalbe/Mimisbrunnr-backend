namespace Mimisbrunnr.Shared.Albums;

public partial class AlbumResponse
{
    public class PostAlbumImage
    {
        public required int Id { get; set; }
    }
}

public partial class AlbumRequest
{
    public class PostAlbumImage
    {
        public required string Url { get; set; }
        public required string Description { get; set; }

        class Validator : AbstractValidator<PostAlbumImage>
        {
            Validator()
            {
                RuleFor(x => x.Url).NotNull().NotEmpty();
                RuleFor(x => x.Description).NotNull();
            }
        }
    }
}