using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Domain.Common;
using Mimisbrunnr.Domain.Praesidium;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Shared.Praesidium;
using Mimisbrunnr.Shared.Praesidium.Dtos;
using static Mimisbrunnr.Services.Mappers.Mappers;

namespace Mimisbrunnr.Services.Praesidium;

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
        var term = await dbContext.PraesidiumTerms.FirstOrDefaultAsync(t => t.Id == id, cancellationToken: cancellationToken);

        if (term is null)
            return Result.NotFound($"Praesidium term with id {id} not found");

        return Result.Success(TermToDetailedDto(term));
    }

    public async Task<Result<PraesidiumResponse.GetYears>> GetPraesidiumYears(CancellationToken cancellationToken = default)
    {
        var years = await dbContext.PraesidiumTerms.Select(t => t.Year).Distinct().ToListAsync(cancellationToken);

        return Result.Success(new PraesidiumResponse.GetYears { Years = years.AsReadOnly() });
    }

    #endregion

    #region SuperSchacht

    public async Task<Result<PraesidiumResponse.GetSuperSchachts>> GetSuperSchachts(CancellationToken cancellationToken = default)
    {
        var superschachts = await dbContext.SuperSchachts.ToListAsync(cancellationToken: cancellationToken);
        var superschachtDtos = superschachts.Select(SuperSchachtToSimpleDto).ToList().AsReadOnly();

        return Result.Success(new PraesidiumResponse.GetSuperSchachts { Schachts = superschachtDtos });
    }

    public async Task<Result<SuperSchachtDto.Detailed>> GetSuperSchachtDetailed(int id, CancellationToken cancellationToken = default)
    {
        var superSchacht = await dbContext.SuperSchachts.FirstOrDefaultAsync(t => t.Id == id, cancellationToken: cancellationToken);
        
        if (superSchacht is null)
            return Result.NotFound($"Superschacht with id {id} not found");

        return Result.Success(SuperSchachtToDetailedDto(superSchacht));
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
        var erelid = await dbContext.Erelids.FirstOrDefaultAsync(t => t.Id == id, cancellationToken: cancellationToken);

        if (erelid is null)
            return Result.NotFound($"Erelids with id {id} not found");

        return Result.Success(ErelidToDetailedDto(erelid));
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
        var lustrumLid = await dbContext.LustrumLids.FirstOrDefaultAsync(l => l.Id == id, cancellationToken: cancellationToken);

        if (lustrumLid is null)
            return Result.NotFound($"Lustrum lid with id {id} not found");

        return Result.Success(LustrumLidToDetailedDto(lustrumLid));
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

    public async Task<Result<PraesidiumResponse.PostPraesidiumMember>> PostPraesidiumMember(PraesidiumRequest.PostPraesidiumMember req, CancellationToken cancellationToken)
    {
        var details = new MemberDetails(req.FirstName!, req.LastName!, req.Quote!, req.Trivia!);

        var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.ImageUrl, cancellationToken: cancellationToken);
        var image = i ?? new Image(req.ImageUrl!);

        var role = await dbContext.PraesidiumRoles.FirstOrDefaultAsync(r => r.Id == req.Role, cancellationToken: cancellationToken);
        if (role is null)
        {
            return Result.NotFound($"Praesidium member with id {req.Role} not found");
        }

        var praesidiumTerm = new PraesidiumTerm(details, image, role, req.Year);

        await dbContext.MemberDetails.AddAsync(details, cancellationToken);
        await dbContext.Images.AddAsync(image, cancellationToken);
        var res = await dbContext.PraesidiumTerms.AddAsync(praesidiumTerm, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(new PraesidiumResponse.PostPraesidiumMember { Id = res.Entity.Id });
    }

    #endregion

    #region PraesdiumRole

    public async Task<Result<PraesidiumResponse.PostPraesidiumRole>> PostPraesidiumRole(PraesidiumRequest.PostPraesidiumRole req, CancellationToken cancellationToken)
    {
        var role = new PraesidiumRole(req.Name!, req.Email!, req.Order);

        var res = await dbContext.PraesidiumRoles.AddAsync(role, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(new PraesidiumResponse.PostPraesidiumRole { Id = res.Entity.Id });
    }

    #endregion

    #region SuperSchacht

    public async Task<Result<PraesidiumResponse.PostSuperSchacht>> PostSuperSchacht(PraesidiumRequest.PostSuperSchacht req, CancellationToken cancellationToken)
    {
        var details = new MemberDetails(req.FirstName!, req.LastName!, req.Quote!, req.Trivia!);

        var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.ImageUrl, cancellationToken: cancellationToken);
        var image = i ?? new Image(req.ImageUrl!);

        var superSchacht = new SuperSchacht(details, image, req.Year);

        await dbContext.MemberDetails.AddAsync(details, cancellationToken);
        await dbContext.Images.AddAsync(image, cancellationToken);
        var res = await dbContext.SuperSchachts.AddAsync(superSchacht, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(new PraesidiumResponse.PostSuperSchacht { Id = res.Entity.Id });
    }

    #endregion

    #region Erelid

    public async Task<Result<PraesidiumResponse.PostErelid>> PostErelid(PraesidiumRequest.PostErelid req, CancellationToken cancellationToken)
    {
        var details = new MemberDetails(req.FirstName!, req.LastName!, req.Quote!, req.Trivia!);

        var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.ImageUrl, cancellationToken: cancellationToken);
        var image = i ?? new Image(req.ImageUrl!);

        var erelid = new Erelid(details, image);

        await dbContext.MemberDetails.AddAsync(details, cancellationToken);
        await dbContext.Images.AddAsync(image, cancellationToken);
        var res = await dbContext.Erelids.AddAsync(erelid, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(new PraesidiumResponse.PostErelid { Id = res.Entity.Id });
    }

    #endregion

    #region Lustrum

    public async Task<Result<PraesidiumResponse.PostLustrumLid>> PostLustrumLid(PraesidiumRequest.PostLustrumLid req, CancellationToken cancellationToken)
    {
        var details = new MemberDetails(req.FirstName!, req.LastName!, req.Quote!, req.Trivia!);

        var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.ImageUrl, cancellationToken: cancellationToken);
        var image = i ?? new Image(req.ImageUrl!);

        var lustrumLid = new LustrumLid(details, image, req.Year);

        await dbContext.MemberDetails.AddAsync(details, cancellationToken);
        await dbContext.Images.AddAsync(image, cancellationToken);
        var res = await dbContext.LustrumLids.AddAsync(lustrumLid, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(new PraesidiumResponse.PostLustrumLid { Id = res.Entity.Id });
    }

    #endregion
    
    #region MemberSocial

    public async Task<Result<PraesidiumResponse.PostMemberSocial>> PostMemberSocial(int id, PraesidiumRequest.PostMemberSocial req, CancellationToken ct)
    {
        var member = await dbContext.MemberDetails
            .Include(m => m.Socials)
            .FirstOrDefaultAsync(m => m.Id == id, ct);
        if (member is null)
            return Result.NotFound($"Member with id {id} not found");
        
        var type = await dbContext.SocialTypes.FirstOrDefaultAsync(t => t.Id == req.TypeId, ct);
        if (type is null)
            return Result.NotFound($"Social type with id {req.TypeId} not found");
        
        member.AddSocial(new Social(type, req.Url));
        
        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new PraesidiumResponse.PostMemberSocial { Id = id });
    }

    #endregion

    
    #endregion

    #region Put

    #region PraesidiumMember

    public async Task<Result<PraesidiumResponse.PutPraesidiumMember>> PutPraesidiumMember(int id, PraesidiumRequest.PutPraesidiumMember req, CancellationToken cancellationToken)
    {
        var term = await dbContext.PraesidiumTerms.Include(t => t.MemberDetails).FirstOrDefaultAsync(t => t.Id == id, cancellationToken: cancellationToken);

        if (term is null)
        {
            return Result.NotFound($"Praesidium member with id {id} not found");
        }

        if (req.FirstName is not null)
        {
            term.MemberDetails.FirstName = req.FirstName;
        }

        if (req.LastName is not null)
        {
            term.MemberDetails.LastName = req.LastName;
        }

        if (req.Quote is not null)
        {
            term.MemberDetails.Quote = req.Quote;
        }

        if (req.Trivia is not null)
        {
            term.MemberDetails.Trivia = req.Trivia;
        }

        if (req.ImageUrl is not null)
        {
            var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.ImageUrl, cancellationToken: cancellationToken);
            var image = i ?? new Image(req.ImageUrl!);
            term.Image = image;
        }

        if (req.Year.HasValue)
        {
            term.Year = req.Year.Value;
        }

        if (req.Role.HasValue)
        {
            var role = await dbContext.PraesidiumRoles.FirstOrDefaultAsync(r => r.Id == req.Role, cancellationToken: cancellationToken);
            if (role is null)
            {
                return Result.NotFound($"Praesidium role with id {id} not found");
            }

            term.Role = role;
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(new PraesidiumResponse.PutPraesidiumMember { Id = term.Id });
    }

    #endregion

    #region PraesidiumRole

    public async Task<Result<PraesidiumResponse.PutPraesidiumRole>> PutPraesidiumRole(int id, PraesidiumRequest.PutPraesidiumRole req, CancellationToken cancellationToken)
    {
        var role = await dbContext.PraesidiumRoles.FirstOrDefaultAsync(r => r.Id == id, cancellationToken: cancellationToken);
        if (role is null)
        {
            return Result.NotFound($"Role with id {id} not found");
        }

        if (req.Name is not null)
        {
            role.Name = req.Name;
        }

        if (req.Email is not null)
        {
            role.Email = new MailAddress(req.Email);
        }

        if (req.Order.HasValue)
        {
            role.Order = req.Order.Value;
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(new PraesidiumResponse.PutPraesidiumRole { Id = role.Id });
    }

    #endregion

    #region Superschacht

    public async Task<Result<PraesidiumResponse.PutSuperSchacht>> PutSuperSchacht(int id, PraesidiumRequest.PutSuperSchacht req, CancellationToken cancellationToken)
    {
        var superSchacht = await dbContext.SuperSchachts.Include(s => s.MemberDetails).FirstOrDefaultAsync(s => s.Id == id, cancellationToken: cancellationToken);
        if (superSchacht is null)
        {
            return Result.NotFound($"Superschacht with id {id} not found");
        }

        if (req.FirstName is not null)
        {
            superSchacht.MemberDetails.FirstName = req.FirstName;
        }

        if (req.LastName is not null)
        {
            superSchacht.MemberDetails.LastName = req.LastName;
        }

        if (req.Quote is not null)
        {
            superSchacht.MemberDetails.Quote = req.Quote;
        }

        if (req.Trivia is not null)
        {
            superSchacht.MemberDetails.Trivia = req.Trivia;
        }

        if (req.ImageUrl is not null)
        {
            var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.ImageUrl, cancellationToken: cancellationToken);
            var image = i ?? new Image(req.ImageUrl!);
            superSchacht.Image = image;
        }

        if (req.Year.HasValue)
        {
            superSchacht.Year = req.Year.Value;
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(new PraesidiumResponse.PutSuperSchacht { Id = superSchacht.Id });
    }

    #endregion

    #region Erelid

    public async Task<Result<PraesidiumResponse.PutErelid>> PutErelid(int id, PraesidiumRequest.PutErelid req, CancellationToken cancellationToken)
    {
        var erelid = await dbContext.Erelids.Include(e => e.MemberDetails).FirstOrDefaultAsync(e => e.Id == id, cancellationToken: cancellationToken);
        if (erelid is null)
        {
            return Result.NotFound($"Erelid with id {id} not found");
        }

        if (req.FirstName is not null)
        {
            erelid.MemberDetails.FirstName = req.FirstName;
        }

        if (req.LastName is not null)
        {
            erelid.MemberDetails.LastName = req.LastName;
        }

        if (req.Quote is not null)
        {
            erelid.MemberDetails.Quote = req.Quote;
        }

        if (req.Trivia is not null)
        {
            erelid.MemberDetails.Trivia = req.Trivia;
        }

        if (req.ImageUrl is not null)
        {
            var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.ImageUrl, cancellationToken: cancellationToken);
            var image = i ?? new Image(req.ImageUrl!);
            erelid.Image = image;
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(new PraesidiumResponse.PutErelid { Id = erelid.Id });
    }

    #endregion

    #region Lustrum

    public async Task<Result<PraesidiumResponse.PutLustrumLid>> PutLustrumLid(int id, PraesidiumRequest.PutLustrumLid req, CancellationToken cancellationToken)
    {
        var lustrumLid = await dbContext.LustrumLids.Include(s => s.MemberDetails).FirstOrDefaultAsync(s => s.Id == id, cancellationToken: cancellationToken);
        if (lustrumLid is null)
        {
            return Result.NotFound($"LustrumLid with id {id} not found");
        }

        if (req.FirstName is not null)
        {
            lustrumLid.MemberDetails.FirstName = req.FirstName;
        }

        if (req.LastName is not null)
        {
            lustrumLid.MemberDetails.LastName = req.LastName;
        }

        if (req.Quote is not null)
        {
            lustrumLid.MemberDetails.Quote = req.Quote;
        }

        if (req.Trivia is not null)
        {
            lustrumLid.MemberDetails.Trivia = req.Trivia;
        }

        if (req.ImageUrl is not null)
        {
            var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.ImageUrl, cancellationToken: cancellationToken);
            var image = i ?? new Image(req.ImageUrl!);
            lustrumLid.Image = image;
        }

        if (req.Year.HasValue)
        {
            lustrumLid.Year = req.Year.Value;
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(new PraesidiumResponse.PutLustrumLid { Id = lustrumLid.Id });
    }

    #endregion

    #endregion

    #region Delete

    #region PraesidiumMember

    public async Task<Result<PraesidiumResponse.DeletePraesidiumMember>> DeletePraesidiumMember(int id, CancellationToken ct)
    {
        var term = await dbContext.PraesidiumTerms.FirstOrDefaultAsync(t => t.Id == id, ct);
        if (term is null)
        {
            return Result.NotFound($"Praesidum member with id {id} not found");
        }

        dbContext.Remove(term);
        await dbContext.SaveChangesAsync(ct);

        return Result.Success(new PraesidiumResponse.DeletePraesidiumMember { Id = term.Id });
    }

    #endregion

    #region PraesidiumRole

    public async Task<Result<PraesidiumResponse.DeletePraesidiumRole>> DeletePraesidiumRole(int id, CancellationToken ct)
    {
        var role = await dbContext.PraesidiumRoles.FirstOrDefaultAsync(t => t.Id == id, ct);
        if (role is null)
        {
            return Result.NotFound($"Praesidum role with id {id} not found");
        }

        dbContext.Remove(role);
        await dbContext.SaveChangesAsync(ct);

        return Result.Success(new PraesidiumResponse.DeletePraesidiumRole { Id = role.Id });
    }

    #endregion

    #region SuperSchacht

    public async Task<Result<PraesidiumResponse.DeleteSuperSchacht>> DeleteSuperSchacht(int id, CancellationToken ct)
    {
        var superSchacht = await dbContext.PraesidiumRoles.FirstOrDefaultAsync(t => t.Id == id, ct);
        if (superSchacht is null)
        {
            return Result.NotFound($"Super schacht with id {id} not found");
        }

        dbContext.Remove(superSchacht);
        await dbContext.SaveChangesAsync(ct);

        return Result.Success(new PraesidiumResponse.DeleteSuperSchacht { Id = superSchacht.Id });
    }

    #endregion

    #region Erelid

    public async Task<Result<PraesidiumResponse.DeleteErelid>> DeleteErelid(int id, CancellationToken ct)
    {
        var erelid = await dbContext.PraesidiumRoles.FirstOrDefaultAsync(t => t.Id == id, ct);
        if (erelid is null)
        {
            return Result.NotFound($"Erelid with id {id} not found");
        }

        dbContext.Remove(erelid);
        await dbContext.SaveChangesAsync(ct);

        return Result.Success(new PraesidiumResponse.DeleteErelid() { Id = erelid.Id });
    }

    #endregion

    #region Lustrum

    public async Task<Result<PraesidiumResponse.DeleteLustrumlid>> DeleteLustrumLid(int id, CancellationToken ct)
    {
        var lustrumLid = await dbContext.PraesidiumRoles.FirstOrDefaultAsync(t => t.Id == id, ct);
        if (lustrumLid is null)
        {
            return Result.NotFound($"Lustrum lid with id {id} not found");
        }

        dbContext.Remove(lustrumLid);
        await dbContext.SaveChangesAsync(ct);

        return Result.Success(new PraesidiumResponse.DeleteLustrumlid { Id = lustrumLid.Id });
    }

    #endregion

    #region MemberSocial

    public async Task<Result<PraesidiumResponse.DeleteMemberSocial>> DeleteMemberSocial(int memberId, int socialId, CancellationToken ct)
    {
        var member = await dbContext.MemberDetails
            .Include(m => m.Socials)
            .FirstOrDefaultAsync(m => m.Id == memberId, ct);
        if (member is null)
            return Result.NotFound($"Member with id {memberId} not found");
        
        var social = await dbContext.Socials.FirstOrDefaultAsync(s => s.Id == socialId, ct);
        if (social is null)
            return Result.NotFound($"Social with id {socialId} not found");
        
        member.RemoveSocial(social);
        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new PraesidiumResponse.DeleteMemberSocial { Id = memberId });
    }

    #endregion
    
    #endregion
}