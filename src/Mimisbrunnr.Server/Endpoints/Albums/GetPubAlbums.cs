using Mimisbrunnr.Shared.Albums;
using Mimisbrunnr.Shared.Common;

namespace Mimisbrunnr.Server.Endpoints.Albums;

public class GetPubAlbums(IAlbumService albumService) : Endpoint<QueryRequest.SkipTake, Result<AlbumResponse.GetAlbums>>
{
    public override void Configure()
    {
        Get("/api/albums/pub");
        AllowAnonymous();
    }

    public override Task<Result<AlbumResponse.GetAlbums>> ExecuteAsync(QueryRequest.SkipTake req, CancellationToken ct)
    {
        return albumService.GetPubAlbums(req, ct);
    }
}