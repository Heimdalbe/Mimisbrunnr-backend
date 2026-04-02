using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Domain.Common;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Shared.Socials;
using Mimisbrunnr.Shared.Socials.Dtos;
using static Mimisbrunnr.Services.Mappers.Mappers;

namespace Mimisbrunnr.Services.Socials;

public class SocialService(ApplicationDbContext dbContext) : ISocialService
{
    #region Get
    
    public async Task<Result<SocialResponse.GetSocials>> GetSocials(CancellationToken ct)
    {
        var socials = dbContext.Socials
            .Include(s => s.Type)
            .ThenInclude(t => t.Icon)
            .ToList();
        var dtos = socials.Select(SocialToSimpleDto).ToList().AsReadOnly();
        
        return Result.Success(new SocialResponse.GetSocials
        {
            Types = dtos
        });
    }
    
    public async Task<Result<SocialDto.Detailed>> GetSocial(int id, CancellationToken ct)
    {
        var social = await dbContext.Socials
            .Include(s => s.Type)
            .ThenInclude(t => t.Icon)
            .FirstOrDefaultAsync(s => s.Id == id, ct);
        
        if (social is null)
            return Result.NotFound($"Social with id {id} not found");
        
        return Result.Success(SocialToDetailedDto(social));
    }
    
    public async Task<Result<SocialResponse.GetSocialTypes>> GetSocialTypes(CancellationToken ct)
    {
        var socials = dbContext.SocialTypes
            .Include(t => t.Icon)
            .ToList();
        var dtos = socials.Select(SocialTypeToSimpleDto).ToList().AsReadOnly();
        
        return Result.Success(new SocialResponse.GetSocialTypes
        {
            Types = dtos
        });
    }
    
    public async Task<Result<SocialTypeDto.Detailed>> GetSocialType(int id, CancellationToken ct)
    {
        var socialType = await dbContext.SocialTypes
            .Include(t => t.Icon)
            .FirstOrDefaultAsync(s => s.Id == id, ct);
        
        if (socialType is null)
            return Result.NotFound($"Social Type with id {id} not found");
        
        return Result.Success(SocialTypeToDetailedDto(socialType));
    }

    #endregion
    
    #region Post
    
    public async Task<Result<SocialResponse.PostSocial>> PostSocial(SocialRequest.PostSocial req, CancellationToken ct)
    {
        var socialType = dbContext.SocialTypes.FirstOrDefault(t => t.Id == req.TypeId);
        if (socialType is null)
            return Result.NotFound($"Social type with id {req.TypeId} not found");

        var social = new Social(socialType, req.Url);
        
        dbContext.Socials.Add(social);
        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new SocialResponse.PostSocial
        {
            Id = social.Id,
        });
    }
    
    public async Task<Result<SocialResponse.PostSocialType>> PostSocialType(SocialRequest.PostSocialType req, CancellationToken ct)
    {
        var icon = dbContext.Images.FirstOrDefault(i => i.Url == req.IconUrl) ?? new Image(req.IconUrl);
        
        var socialType = new SocialType(req.Name, icon);
        
        dbContext.SocialTypes.Add(socialType);
        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new SocialResponse.PostSocialType
        {
            Id = socialType.Id,
        });
    }
    
    #endregion
    
    #region Put
    
    public async Task<Result<SocialResponse.PutSocial>> PutSocial(int id, SocialRequest.PutSocial req, CancellationToken ct)
    {
        var social = dbContext.Socials.FirstOrDefault(s => s.Id == id);
        if (social is null)
            return Result.NotFound($"Social with id {id} not found");
        
        if(req.Url is not null)
            social.Url = req.Url;

        if (req.TypeId is not null)
        {
            var type =  dbContext.SocialTypes.FirstOrDefault(t => t.Id == req.TypeId);
            
            if (type is null)
                return Result.NotFound($"Social type with id {req.TypeId} not found");
            
            social.Type = type;
        }

        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new SocialResponse.PutSocial
        {
            Id = social.Id,
        });
    }
    
    public async Task<Result<SocialResponse.PutSocialType>> PutSocialType(int id, SocialRequest.PutSocialType req, CancellationToken ct)
    {
        var socialType = dbContext.SocialTypes.FirstOrDefault(s => s.Id == id);
        if (socialType is null)
            return Result.NotFound($"Social type with id {id} not found");
        
        if(req.Name is not null)
            socialType.Name = req.Name;

        if (req.IconUrl is not null)
        {
            var icon =  dbContext.Images.FirstOrDefault(i => i.Url == req.IconUrl) ?? new Image(req.IconUrl);
            
            socialType.Icon = icon;
        }

        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new SocialResponse.PutSocialType
        {
            Id = socialType.Id,
        });
    }
    
    #endregion
    
    #region Delete
    
    public async Task<Result<SocialResponse.DeleteSocial>> DeleteSocial(int id, CancellationToken ct)
    {
        var  social = await dbContext.Socials.FirstOrDefaultAsync(s => s.Id == id, cancellationToken: ct);
        if (social is null)
            return Result.NotFound($"Social with id {id} not found");
        
        dbContext.Socials.Remove(social);
        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new SocialResponse.DeleteSocial
        {
            Id = social.Id,
        });
    }
    
    public async Task<Result<SocialResponse.DeleteSocialType>> DeleteSocialType(int id, CancellationToken ct)
    {
        var socialType = await dbContext.SocialTypes.FirstOrDefaultAsync(t => t.Id == id, cancellationToken: ct);
        if (socialType is null)
            return Result.NotFound($"Social type with id {id} not found");
        
        dbContext.SocialTypes.Remove(socialType);
        await dbContext.SaveChangesAsync(ct);

        return Result.Success(new SocialResponse.DeleteSocialType
            {
                Id = socialType.Id,
            }
        );
    }
    
    #endregion
}