using Mimisbrunnr.Shared.Albums;
using Mimisbrunnr.Shared.Albums.Dtos;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Albums;

public class GetAlbumById(IAlbumService albumService) : EndpointWithoutRequest<Result<AlbumDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/albums/{id:int}");
        Roles(AppRoles.MediaEditor, AppRoles.Hmdl);
    }

    public override Task<Result<AlbumDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        return albumService.GetAlbum(id, ct);
    }
}