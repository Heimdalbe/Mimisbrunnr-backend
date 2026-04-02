using Mimisbrunnr.Shared.Albums;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Albums;

public class PostAlbumImagesByImgurAlbum(IAlbumService albumService) : Endpoint<AlbumRequest.PostAlbumImagesByImgurAlbum, Result<AlbumResponse.PostAlbumImagesByImgurAlbum>>
{
    public override void Configure()
    {
        Put("/api/albums/{id:int}/images");
        Roles(AppRoles.MediaEditor, AppRoles.Hmdl);
    }

    public override Task<Result<AlbumResponse.PostAlbumImagesByImgurAlbum>> ExecuteAsync(AlbumRequest.PostAlbumImagesByImgurAlbum req, CancellationToken ct)
    {
        var id = Route<int>("id");
        return albumService.PostImagesByImgurAlbum(id, req, ct);
    }
}