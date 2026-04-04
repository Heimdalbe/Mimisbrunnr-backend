using Mimisbrunnr.Shared.Albums.Dtos;
using Mimisbrunnr.Shared.Common.Dtos;

namespace Mimisbrunnr.Shared.Albums;

public partial class AlbumResponse
{
    public class GetAlbums
    {
        public required IReadOnlyList<AlbumDto.Simple> Albums { get; set; }
    }
}