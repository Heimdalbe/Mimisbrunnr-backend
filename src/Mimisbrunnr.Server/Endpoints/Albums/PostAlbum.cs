using Mimisbrunnr.Shared.Albums;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Albums;

public class PostAlbum(IAlbumService albumService) : Endpoint<AlbumRequest.PostAlbum, Result<AlbumResponse.PostAlbum>>
{
    public override void Configure()
    {
        Post("/api/albums");
        Roles(AppRoles.MediaEditor, AppRoles.Hmdl);
    }

    public override Task<Result<AlbumResponse.PostAlbum>> ExecuteAsync(AlbumRequest.PostAlbum req, CancellationToken ct)
    {
        return albumService.PostAlbum(req, ct);
    }
}