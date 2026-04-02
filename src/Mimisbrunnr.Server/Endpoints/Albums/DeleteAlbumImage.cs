using Mimisbrunnr.Shared.Albums;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Albums;

public class DeleteAlbumImage(IAlbumService albumService) : EndpointWithoutRequest<Result<AlbumResponse.DeleteAlbumImage>>
{
    public override void Configure()
    {
        Delete("/api/albums/{albumId:int}/images/{imageId:int}");
        Roles(AppRoles.MediaEditor, AppRoles.Hmdl);
    }

    public override Task<Result<AlbumResponse.DeleteAlbumImage>> ExecuteAsync(CancellationToken ct)
    {
        var albumId = Route<int>("albumId");
        var imageId = Route<int>("imageId");
        
        return albumService.DeleteAlbumImage(albumId, imageId, ct);
    }
}