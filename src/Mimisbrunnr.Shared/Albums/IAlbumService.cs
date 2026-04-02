using Mimisbrunnr.Shared.Albums.Dtos;

namespace Mimisbrunnr.Shared.Albums;

public interface IAlbumService
{
    Task<Result<AlbumResponse.GetAlbums>> GetPubAlbums(CancellationToken ct);
    
    Task<Result<AlbumResponse.GetAlbums>> GetAlbums(CancellationToken ct);

    Task<Result<AlbumDto.Detailed>> GetPubAlbum(int id, CancellationToken ct);
    
    Task<Result<AlbumDto.Detailed>> GetAlbum(int id, CancellationToken ct);
    
    Task<Result<AlbumResponse.PostAlbum>> PostAlbum(AlbumRequest.PostAlbum req, CancellationToken ct);

    Task<Result<AlbumResponse.PostAlbumImage>> PostAlbumImage(int id, AlbumRequest.PostAlbumImage req, CancellationToken ct);
   
    Task<Result<AlbumResponse.PostAlbumImagesByImgurAlbum>> PostImagesByImgurAlbum(int id, AlbumRequest.PostAlbumImagesByImgurAlbum req, CancellationToken ct);

    Task<Result<AlbumResponse.PutAlbum>> PutAlbum(int id, AlbumRequest.PutAlbum req, CancellationToken ct);

    Task<Result<AlbumResponse.DeleteAlbum>> DeleteAlbum(int id, CancellationToken ct);

    Task<Result<AlbumResponse.DeleteAlbumImage>> DeleteAlbumImage(int albumId, int imageId, CancellationToken ct);
}