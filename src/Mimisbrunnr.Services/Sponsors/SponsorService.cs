using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Shared.Sponsors;
using Mimisbrunnr.Domain.Common;
using Mimisbrunnr.Domain.Sponsors;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Shared.Sponsors.Dtos;
using static Mimisbrunnr.Services.Mappers.Mappers;

namespace Mimisbrunnr.Services.Sponsors;

public class SponsorService(ApplicationDbContext dbContext) : ISponsorService
{
    #region Get

    public async Task<Result<SponsorResponse.GetSponsors>> GetSponsors(CancellationToken cancellationToken = default)
    {
        var sponsors = await dbContext.Sponsors
            .Include(s => s.Logo)
            .ToListAsync(cancellationToken: cancellationToken);
        var dtos = sponsors.Select(SponsorToSimpleDto).ToList().AsReadOnly();

        return Result.Success(new SponsorResponse.GetSponsors { Sponsors = dtos });
    }

    public async Task<Result<SponsorDto.Detailed>> GetSponsor(int id, CancellationToken cancellationToken = default)
    {
        var sponsor = await dbContext.Sponsors
            .Include(s => s.Logo)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (sponsor is null)
            return Result.NotFound($"Sponsor with id {id} not found");

        return Result.Success(SponsorToDetailedDto(sponsor));
    }

    #endregion

    #region Post

    public async Task<Result<SponsorResponse.PostSponsor>> PostSponsor(SponsorRequest.PostSponsor req, CancellationToken cancellationToken = default)
    {
        var logo = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.LogoUrl, cancellationToken) ?? new Image(req.LogoUrl);

        var success = Enum.TryParse(req.SponsorRank,true, out SponsorRank sponsorRank);
        if(!success)
            return Result.NotFound($"Sponsor rank {sponsorRank} not found");
        
        success = Enum.TryParse(req.LanSponsorRank, out LanSponsorRank lanSponsorRank);
        if(!success)
            return Result.NotFound($"LanSponsor rank {lanSponsorRank} not found");

        var sponsor = new Sponsor(req.Name, logo, req.Website, req.Benefits, sponsorRank, lanSponsorRank, req.Order);

        dbContext.Sponsors.Add(sponsor);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(new SponsorResponse.PostSponsor { Id = sponsor.Id });
    }

    #endregion

    #region Put

    public async Task<Result<SponsorResponse.PutSponsor>> PutSponsor(int id, SponsorRequest.PutSponsor req, CancellationToken cancellationToken = default)
    {
        var sponsor = await dbContext.Sponsors.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (sponsor is null)
            return Result.NotFound($"Sponsor with id {id} not found");

        
        if (req.Name is not null)
            sponsor.Name = req.Name;

        if (req.LogoUrl is not null)
        {
            sponsor.Logo = dbContext.Images.FirstOrDefault(x => x.Url == req.LogoUrl) ?? new Image(req.LogoUrl);
        }
        
        if (req.Website is not null)
            sponsor.Website = req.Website;

        if (req.Benefits is not null)
            sponsor.Benefits = req.Benefits;
        
        if (req.SponsorRank is not null)
        {
            Enum.TryParse(req.SponsorRank,true, out SponsorRank sponsorRank);
            sponsor.SponsorRank = sponsorRank;
        }

        else if (req.LanSponsorRank is not null)
        {
            Enum.TryParse(req.LanSponsorRank, out LanSponsorRank lanSponsorRank);
            sponsor.LanSponsorRank = lanSponsorRank;
        }

        if (req.Order is not null)
            sponsor.Order = req.Order.Value;
        
        
        dbContext.Sponsors.Add(sponsor);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(new SponsorResponse.PutSponsor { Id = sponsor.Id });
    }

    #endregion

    #region Delete

    public async Task<Result<SponsorResponse.DeleteSponsor>> DeleteSponsor(int id, CancellationToken cancellationToken = default)
    {
        var sponsor = await dbContext.Sponsors.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        
        if (sponsor is null)
            return Result.NotFound($"Sponsor with id {id} not found");
        
        dbContext.Remove(sponsor);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Result.Success(new SponsorResponse.DeleteSponsor { Id = id });
    }

    #endregion
}