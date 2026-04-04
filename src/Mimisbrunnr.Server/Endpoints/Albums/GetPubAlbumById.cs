using Mimisbrunnr.Shared.Albums;
using Mimisbrunnr.Shared.Albums.Dtos;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Albums;

public class GetPubAlbumById(IAlbumService albumService) : EndpointWithoutRequest<Result<AlbumDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/albums/pub/{id:int}");
    }

    public override Task<Result<AlbumDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        return albumService.GetPubAlbum(id, ct);
    }
}