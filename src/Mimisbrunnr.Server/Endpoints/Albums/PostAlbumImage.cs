using Mimisbrunnr.Shared.Albums;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Albums;

public class PostAlbumImage(IAlbumService albumService) : Endpoint<AlbumRequest.PostAlbumImage, Result<AlbumResponse.PostAlbumImage>>
{
    public override void Configure()
    {
        Post("/api/albums/{id:int}");
        Roles(AppRoles.MediaEditor, AppRoles.Hmdl);
    }

    public override Task<Result<AlbumResponse.PostAlbumImage>> ExecuteAsync(AlbumRequest.PostAlbumImage req, CancellationToken ct)
    {
        var id = Route<int>("id");
        return albumService.PostAlbumImage(id, req, ct);
    }
}