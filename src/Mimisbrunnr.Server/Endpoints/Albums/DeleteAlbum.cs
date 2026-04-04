using Mimisbrunnr.Shared.Albums;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Albums;

public class DeleteAlbum(IAlbumService albumService) : EndpointWithoutRequest<Result<AlbumResponse.DeleteAlbum>>
{
    public override void Configure()
    {
        Delete("/api/albums/{id:int}");
        Roles(AppRoles.MediaEditor, AppRoles.Hmdl);
    }

    public override Task<Result<AlbumResponse.DeleteAlbum>> ExecuteAsync(CancellationToken ct)
    {
        int id = Route<int>("id");
        return albumService.DeleteAlbum(id, ct);
    }
}