namespace Mimisbrunnr.Shared.Albums;

public partial class AlbumResponse
{
    public class PostAlbumImagesByImgurAlbum
    {
        public required int Id { get; set; }
    }
}

public partial class AlbumRequest
{
    public class PostAlbumImagesByImgurAlbum
    {
        public required string AlbumUrl { get; set; }
    }
    
    public class Validator : AbstractValidator<PostAlbumImagesByImgurAlbum>
    {
        public Validator()
        {
            RuleFor(x => x.AlbumUrl).NotNull().Matches(@"^(?:https?://)?(?:i\.)?imgur\.com/(?:a|gallery)/(.*)-([A-Za-z0-9]{5,7})");
        }
    }
}