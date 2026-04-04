using Mimisbrunnr.Shared.Albums;

namespace Mimisbrunnr.Server.Endpoints.Albums;

public class GetPubAlbums(IAlbumService albumService) : EndpointWithoutRequest<Result<AlbumResponse.GetAlbums>>
{
    public override void Configure()
    {
        Get("/api/albums/pub");
    }

    public override Task<Result<AlbumResponse.GetAlbums>> ExecuteAsync(CancellationToken ct)
    {
        return albumService.GetPubAlbums(ct);
    }
}