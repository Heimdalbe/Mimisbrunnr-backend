using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Domain.Albums;
using Mimisbrunnr.Domain.Common;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Shared.Albums;
using Mimisbrunnr.Shared.Albums.Dtos;
using Mimisbrunnr.Shared.Common.Dtos;
using static Mimisbrunnr.Services.Mappers.Mappers;

namespace Mimisbrunnr.Services.Albums;

public class AlbumService(ApplicationDbContext dbContext, IHttpClientFactory httpClientFactory) : IAlbumService
{
    #region Get

    public async Task<Result<AlbumResponse.GetAlbums>> GetPubAlbums(CancellationToken ct)
    {
        var albums = await dbContext.Albums
            .Include(a => a.CoverImage)
            .Where(a => a.Published).ToListAsync(ct);
        var dtos = albums.Select(AlbumToSimpleDto).ToList().AsReadOnly();
        
        return Result.Success(new AlbumResponse.GetAlbums{ Albums = dtos });
    }
    
    public async Task<Result<AlbumResponse.GetAlbums>> GetAlbums(CancellationToken ct)
    {
        var albums = await dbContext.Albums
            .Include(a => a.CoverImage)
            .ToListAsync(ct);
        var dtos = albums.Select(AlbumToSimpleDto).ToList().AsReadOnly();
        
        return Result.Success(new AlbumResponse.GetAlbums{ Albums = dtos });
    }
    
    
    public async Task<Result<AlbumDto.Detailed>> GetPubAlbum(int id, CancellationToken ct)
    {
        var album = await dbContext.Albums
            .Include(a => a.CoverImage)
            .Include(a => a.Images)
            .FirstOrDefaultAsync(a => a.Id == id && a.Published, ct);
        
        if (album is null)
            return Result.NotFound($"Album with id {id} not found");
        
        return Result.Success(AlbumToDetailedDto(album));
    }
    
    public async Task<Result<AlbumDto.Detailed>> GetAlbum(int id, CancellationToken ct)
    {
        var album = await dbContext.Albums
            .Include(a => a.CoverImage)
            .Include(a => a.Images)
            .FirstOrDefaultAsync(a => a.Id == id, ct);
        
        if (album is null)
            return Result.NotFound($"Album with id {id} not found");
        
        return Result.Success(AlbumToDetailedDto(album));
    }
    
    #endregion
    
    #region Post
    
    public async Task<Result<AlbumResponse.PostAlbum>> PostAlbum(AlbumRequest.PostAlbum req, CancellationToken ct)
    {
        Album album;
        if (req.CoverImageUrl is not null)
        {
            var coverImage = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.CoverImageUrl, cancellationToken: ct) ?? new Image(req.CoverImageUrl);
            album = new Album(req.Name, req.Year, req.Description, req.Published, coverImage);
        }
        else
            album = new Album(req.Name, req.Year, req.Description, req.Published);
        
        dbContext.Albums.Add(album);
        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new AlbumResponse.PostAlbum{Id = album.Id});
    }
    
    public async Task<Result<AlbumResponse.PostAlbumImage>> PostAlbumImage(int id, AlbumRequest.PostAlbumImage req, CancellationToken ct)
    {
        var album = await dbContext.Albums.Include(a => a.Images).FirstOrDefaultAsync(a => a.Id == id, ct);
        
        if (album is null)
            return Result.NotFound($"Album with id {id} not found");
        
        var image = dbContext.Images.FirstOrDefault(i => i.Url == req.Url) ?? new Image(req.Url);
        album.AddImage(image);
        
        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new AlbumResponse.PostAlbumImage{Id = album.Id});
    }
    
    public async Task<Result<AlbumResponse.PostAlbumImagesByImgurAlbum>> PostImagesByImgurAlbum(int id, AlbumRequest.PostAlbumImagesByImgurAlbum req, CancellationToken ct)
    {
        var album = await dbContext.Albums.Include(a => a.Images).FirstOrDefaultAsync(a => a.Id == id, ct);
        
        if (album is null)
            return Result.NotFound($"Album with id {id} not found");

        var regex = new Regex(@"([A-Za-z0-9]{5,7})$");
        var match = regex.Match(req.AlbumUrl);
        if (!match.Success)
            return Result.Error("Invalid Imgur album URL");

        var key = match.Groups[1].Value;
        
        var client = httpClientFactory.CreateClient("SecureApi");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", "771f08ac2c9301e");
        var url = $"https://api.imgur.com/3/album/{key}";

        try
        {
            var response = await client.GetAsync(url, ct);
            
            try
            {
                var result = await response.Content.ReadFromJsonAsync<ImgurAlbumResponse>(ct);
                
                if (result is not null)
                {
                    var images = result.Data.Images.Select(i => dbContext.Images.FirstOrDefault(im => im.Url == i.Link) ?? new Image(i.Link)).ToList();

                    album.Images = images;
                }
                
            }
            catch
            {
                return Result.Error("Internal server error");
            }
        }
        catch
        {
            return Result.Error("Internal server error");            
        }
        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new AlbumResponse.PostAlbumImagesByImgurAlbum{ Id = album.Id} );
    }
    
    #endregion
    
    #region Put

    public async Task<Result<AlbumResponse.PutAlbum>> PutAlbum(int id, AlbumRequest.PutAlbum req, CancellationToken ct)
    {
        var album = await dbContext.Albums.FirstOrDefaultAsync(a => a.Id == id, ct);
        
        if (album is null)
            return Result.NotFound($"Album with id {id} not found");
        
        if(req.Name is not null)
            album.Name = req.Name;
        
        if (req.Year is not null)
            album.Year = req.Year.Value;

        if (req.CoverImageUrl is not null)
        {
            var image = dbContext.Images.FirstOrDefault(i => i.Url == req.CoverImageUrl) ?? new Image(req.CoverImageUrl);
            album.CoverImage = image;
        }
        
        if(req.Description is not null)
            album.Description = req.Description;
        
        if (req.Published is not null)
            album.Published = req.Published.Value;
        
        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new AlbumResponse.PutAlbum{Id = album.Id});
    }
    
    #endregion
    
    #region Delete
    
    public async Task<Result<AlbumResponse.DeleteAlbum>> DeleteAlbum(int id, CancellationToken ct)
    {
        var album = await dbContext.Albums.FirstOrDefaultAsync(a => a.Id == id, ct);
        
        if (album is null)
            return Result.NotFound($"Album with id {id} not found");
        
        dbContext.Remove(album);
        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new AlbumResponse.DeleteAlbum{ Id = album.Id});
    }

    public async Task<Result<AlbumResponse.DeleteAlbumImage>> DeleteAlbumImage(int albumId, int imageId, CancellationToken ct)
    {
        var album = await dbContext.Albums.Include(album => album.Images).FirstOrDefaultAsync(a => a.Id == albumId, ct);
        
        if (album is null)
            return Result.NotFound($"Album with id {albumId} not found");
        
        var image = await dbContext.Images.FirstOrDefaultAsync(i => i.Id == imageId, ct);
        
        if(image is null || !album.Images.Contains(image))
            return Result.NotFound($"Image with id {imageId} not found");
        
        album.RemoveImage(image);

        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new AlbumResponse.DeleteAlbumImage{ Id = album.Id});
    }
    
    #endregion
}