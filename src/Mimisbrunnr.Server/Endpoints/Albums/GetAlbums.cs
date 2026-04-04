using Mimisbrunnr.Shared.Albums;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Albums;

public class GetAlbums(IAlbumService albumService) : EndpointWithoutRequest<Result<AlbumResponse.GetAlbums>>
{
    public override void Configure()
    {
        Get("/api/albums");
        Roles(AppRoles.MediaEditor, AppRoles.Hmdl);
    }

    public override Task<Result<AlbumResponse.GetAlbums>> ExecuteAsync(CancellationToken ct)
    {
        return albumService.GetAlbums(ct);
    }
}