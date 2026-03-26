using Microsoft.EntityFrameworkCore;
using Mimmisbrunnr.Domain.Common;
using Mimmisbrunnr.Domain.Praesidium;
using Mimmisbrunnr.Persistence;
using Mimmisbrunnr.Shared.Praesidium;
using Mimmisbrunnr.Shared.Praesidium.Dtos;
using static Mimmisbrunnr.Services.Mappers.Mappers;

namespace Mimmisbrunnr.Services.Praesidium;

public class PraesidiumService(ApplicationDbContext dbContext) : IPraesidiumService
{
    #region Get
    
    #region PraesidiumMember

    public async Task<Result<PraesidiumResponse.GetPraesidiumOfYear>> GetPraesidiumOfYear(int year, CancellationToken cancellationToken = default)
    {
        var praesidium = await dbContext.PraesidiumTerms.Where(t => t.Year == year).ToListAsync(cancellationToken);
        var praesidiumDtos = praesidium.Select(TermToSimpleDto).ToList().AsReadOnly();

        return Result.Success(new PraesidiumResponse.GetPraesidiumOfYear { Praesidium = praesidiumDtos });
    }

    public async Task<Result<PraesidiumTermDto.Detailed>> GetPraesidiumTermDetailed(int id, CancellationToken cancellationToken = default)
    {
        var term = await dbContext.PraesidiumTerms.FirstAsync(t => t.Id == id, cancellationToken: cancellationToken);

        return TermToDetailedDto(term);
    }

    public async Task<Result<PraesidiumResponse.GetYears>> GetPraesidiumYears(CancellationToken cancellationToken = default)
    {
        var years = await dbContext.PraesidiumTerms.Select(t => t.Year).Distinct().ToListAsync(cancellationToken);

        return Result.Success(new PraesidiumResponse.GetYears { Years = years.AsReadOnly() });
    }

    #endregion

    #region SuperSchacht

    public async Task<Result<PraesidiumResponse.GetSuperSchachts>> GetSuperschachts(CancellationToken cancellationToken = default)
    {
        var superschachts = await dbContext.SuperSchachts.ToListAsync(cancellationToken: cancellationToken);
        var superschachtDtos = superschachts.Select(SuperSchachtToSimpleDto).ToList().AsReadOnly();

        return Result.Success(new PraesidiumResponse.GetSuperSchachts { Schachts = superschachtDtos });
    }

    public async Task<Result<SuperSchachtDto.Detailed>> GetSuperschachtDetailed(int id, CancellationToken cancellationToken = default)
    {
        var superSchacht = await dbContext.SuperSchachts.FirstAsync(t => t.Id == id, cancellationToken: cancellationToken);

        return SuperSchachtToDetailedDto(superSchacht);
    }

    #endregion

    #region Erelid

    public async Task<Result<PraesidiumResponse.GetErelids>> GetErelids(CancellationToken cancellationToken = default)
    {
        var erelids = await dbContext.Erelids.ToListAsync(cancellationToken: cancellationToken);
        var erelidDtos = erelids.Select(ErelidToSimpleDto).ToList().AsReadOnly();

        return Result.Success(new PraesidiumResponse.GetErelids { Erelids = erelidDtos });
    }

    public async Task<Result<ErelidDto.Detailed>> GetErelidDetailed(int id, CancellationToken cancellationToken = default)
    {
        var erelid = await dbContext.Erelids.FirstAsync(t => t.Id == id, cancellationToken: cancellationToken);

        return ErelidToDetailedDto(erelid);
    }

    #endregion

    #region Lustrum

    public async Task<Result<PraesidiumResponse.GetLustrumLids>> GetLustrumLids(int year, CancellationToken cancellationToken = default)
    {
        var lustrumLids = await dbContext.LustrumLids.Where(l => l.Year == year).ToListAsync(cancellationToken: cancellationToken);
        var lustrumDtos = lustrumLids.Select(LustrumLidToSimpleDto).ToList().AsReadOnly();

        return Result.Success(new PraesidiumResponse.GetLustrumLids { LustrumLids = lustrumDtos });
    }

    public async Task<Result<LustrumLidDto.Detailed>> GetLustrumlidDetailed(int id, CancellationToken cancellationToken = default)
    {
        var lustrumLid = await dbContext.LustrumLids.FirstAsync(l => l.Id == id, cancellationToken: cancellationToken);

        return LustrumLidToDetailedDto(lustrumLid);
    }

    public async Task<Result<PraesidiumResponse.GetYears>> GetLustrumYears(CancellationToken cancellationToken = default)
    {
        var years = await dbContext.LustrumLids.Select(t => t.Year).Distinct().ToListAsync(cancellationToken);

        return Result.Success(new PraesidiumResponse.GetYears { Years = years.AsReadOnly() });
    }

    #endregion
    
    #endregion
    
    #region Post

    #region PraesidiumMember

    public async Task<PraesidiumResponse.PostPraesidiumMember> PostPraesidiumMember(PraesidiumRequest.PostPraesidiumMember req, CancellationToken cancellationToken)
    {
        var details  = new MemberDetails(req.FirstName!, req.LastName!, req.Quote!, req.Trivia!);
        var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.ImageUrl, cancellationToken: cancellationToken);
        var image = i ?? new Image(req.ImageUrl!);
        var role = await dbContext.PraesidiumRoles.FirstAsync(r => r.Id == req.Role, cancellationToken: cancellationToken);
        var praesidiumTerm = new PraesidiumTerm(details, image, role, req.Year);
        
        await dbContext.MemberDetails.AddAsync(details, cancellationToken);
        await dbContext.Images.AddAsync(image, cancellationToken);
        var res = await dbContext.PraesidiumTerms.AddAsync(praesidiumTerm, cancellationToken);
        return new PraesidiumResponse.PostPraesidiumMember { Id = res.Entity.Id };
    }
    
    #endregion

    #region PraesdiumRole

    public async Task<PraesidiumResponse.PostPraesidiumRole> PostPraesidiumRole(PraesidiumRequest.PostPraesidiumRole req, CancellationToken cancellationToken)
    {
        var role = new PraesidiumRole(req.name!, req.email!, req.order);
        
        var res = await dbContext.PraesidiumRoles.AddAsync(role, cancellationToken);
        return new PraesidiumResponse.PostPraesidiumRole{ Id = res.Entity.Id };
    }

    #endregion

    #region SuperSchacht
    
    public async Task<PraesidiumResponse.PostSuperSchacht> PostSuperSchacht(PraesidiumRequest.PostSuperSchacht req, CancellationToken cancellationToken)
    {
        var details = new MemberDetails(req.FirstName!, req.LastName!, req.Quote!, req.Trivia!);
        var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.ImageUrl, cancellationToken: cancellationToken);
        var image = i ?? new Image(req.ImageUrl!);
        var superSchacht = new SuperSchacht(details, image, req.Year);
        
        await dbContext.MemberDetails.AddAsync(details, cancellationToken);
        await dbContext.Images.AddAsync(image, cancellationToken);
        var res = await dbContext.SuperSchachts.AddAsync(superSchacht, cancellationToken);
        return new PraesidiumResponse.PostSuperSchacht { Id = res.Entity.Id };
    }

    #endregion

    #region Erelid

    public async Task<PraesidiumResponse.PostErelid> PostErelid(PraesidiumRequest.PostErelid req, CancellationToken cancellationToken)
    {
        var details = new MemberDetails(req.FirstName!, req.LastName!, req.Quote!, req.Trivia!);
        var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.ImageUrl, cancellationToken: cancellationToken);
        var image = i ?? new Image(req.ImageUrl!);
        var erelid = new Erelid(details, image);
        
        await dbContext.MemberDetails.AddAsync(details, cancellationToken);
        await dbContext.Images.AddAsync(image, cancellationToken);
        var res = await dbContext.Erelids.AddAsync(erelid, cancellationToken);
        return new PraesidiumResponse.PostErelid { Id = res.Entity.Id };
    }

    #endregion

    #region Lustrum
    
    public async Task<PraesidiumResponse.PostLustrumLid> PostLustrumLid(PraesidiumRequest.PostLustrumLid req, CancellationToken cancellationToken)
    {
        var details = new MemberDetails(req.FirstName!, req.LastName!, req.Quote!, req.Trivia!);
        var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.ImageUrl, cancellationToken: cancellationToken);
        var image = i ?? new Image(req.ImageUrl!);
        var lustrumLid = new LustrumLid(details, image, req.Year);
        
        await dbContext.MemberDetails.AddAsync(details, cancellationToken);
        await dbContext.Images.AddAsync(image, cancellationToken);
        var res = await dbContext.LustrumLids.AddAsync(lustrumLid, cancellationToken);
        return new PraesidiumResponse.PostLustrumLid { Id = res.Entity.Id };
    }

    #endregion
    
    #endregion

    #region Put
    #endregion
    
    #region Delete
    #endregion
}