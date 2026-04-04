using Mimisbrunnr.Shared.Common.Dtos;

namespace Mimisbrunnr.Shared.Albums.Dtos;

public static class AlbumDto
{
    public class Simple
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required ImageDto.Simple? CoverImage { get; set; }
        
        public required bool Published { get; set; }
    }
    
    public class Detailed
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required ImageDto.Simple? CoverImage { get; set; }
        public required IReadOnlyCollection<ImageDto.Simple> Images { get; set; }
        public required string Description { get; set; }
        public required bool Published { get; set; }
    }
}