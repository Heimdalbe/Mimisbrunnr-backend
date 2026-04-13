namespace Mimisbrunnr.Shared.Common.Dtos;

public class ImgurAlbumResponse
{
    public bool Success { get; set; }
    public int Status { get; set; }
    public ImgurAlbumData Data { get; set; }
}

public class ImgurAlbumData
{
    public string Id { get; set; }
    public string Title { get; set; }
    public List<ImgurImage> Images { get; set; }
}

public class ImgurImage
{
    public string Id { get; set; }
    public string Link { get; set; }
    public string Name { get; set; }
}