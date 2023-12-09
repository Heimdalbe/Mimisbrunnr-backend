namespace Mimisbrunnr.Models
{
    public class Picture: ModelBase
    {
        public string Url { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public Picture() { }
    }
}
