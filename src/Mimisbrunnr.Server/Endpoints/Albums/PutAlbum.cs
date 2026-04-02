using Mimisbrunnr.Shared.Albums;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Albums;

public class PutAlbum(IAlbumService albumService) : Endpoint<AlbumRequest.PutAlbum, Result<AlbumResponse.PutAlbum>>
{
    public override void Configure()
    {
        Put("/api/albums/{id:int}");
        Roles(AppRoles.MediaEditor, AppRoles.Hmdl);
    }

    public override Task<Result<AlbumResponse.PutAlbum>> ExecuteAsync(AlbumRequest.PutAlbum req, CancellationToken ct)
    {
        var id = Route<int>("id");
        return albumService.PutAlbum(id, req, ct);
    }
}