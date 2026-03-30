using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Domain.Common;
using Mimisbrunnr.Domain.Events;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Common;
using Mimisbrunnr.Shared.Events;
using Mimisbrunnr.Shared.Events.Dtos;
using Mimisbrunnr.Shared.Identity;
using Mimisbrunnr.Persistence;
using static Mimisbrunnr.Services.Mappers.Mappers;

namespace Mimisbrunnr.Services.Events;

public class EventService(ApplicationDbContext dbContext) : IEventService
{
    #region Get

    public async Task<Result<EventResponse.GetEvents>> GetOpenEvents(QueryRequest.SkipTake req, CancellationToken ct)
    {
        var events = await dbContext.Events.Where(e => e.Published && e.Accessibility == Accessibility.OPEN).ToListAsync(cancellationToken: ct);

        var dtos = events.Select(EventToSimpleDto)
            .Skip(req.Skip)
            .Take(req.Take)
            .OrderBy(e => e.Start)
            .ToList().AsReadOnly();

        return Result.Success(new EventResponse.GetEvents { Events = dtos });
    }

    public async Task<Result<EventResponse.GetEvents>> GetPublishedEvents(QueryRequest.SkipTake req, CancellationToken ct)
    {
        var events = await dbContext.Events.Where(e => e.Published).ToListAsync(cancellationToken: ct);

        var dtos = events.Select(EventToSimpleDto)
            .Skip(req.Skip)
            .Take(req.Take)
            .OrderBy(e => e.Start)
            .ToList().AsReadOnly();

        return Result.Success(new EventResponse.GetEvents { Events = dtos });
    }

    public async Task<Result<EventResponse.GetEvents>> GetEvents(CancellationToken ct)
    {
        var events = await dbContext.Events.ToListAsync(cancellationToken: ct);

        var dtos = events.Select(EventToSimpleDto)
            .OrderBy(e => e.Start)
            .ToList().AsReadOnly();

        return Result.Success(new EventResponse.GetEvents { Events = dtos });
    }

    public async Task<Result<EventDto.Detailed>> GetOpenEvent(int id, CancellationToken ct)
    {
        var e = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id && e.Published && e.Accessibility == Accessibility.OPEN, ct);

        if (e is null)
            return Result.NotFound($"Event with id {id} not found");

        return Result.Success(EventToDetailedDto(e));
    }

    public async Task<Result<EventDto.Detailed>> GetPublishedEvent(int id, CancellationToken ct)
    {
        var e = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id && e.Published, ct);

        if (e is null)
            return Result.NotFound($"Event with id {id} not found");

        return Result.Success(EventToDetailedDto(e));
    }

    public async Task<Result<EventDto.Detailed>> GetEvent(int id, CancellationToken ct)
    {
        var e = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id, ct);

        if (e is null)
            return Result.NotFound($"Event with id {id} not found");

        return Result.Success(EventToDetailedDto(e));
    }

    #endregion

    #region Post

    public async Task<Result<EventResponse.PostEvent>> PostEvent(EventRequest.PostEvent req, CancellationToken ct)
    {
        var success = Enum.TryParse(req.Category, out Category category);
        if (!success)
            return Result.NotFound($"Category with value {req.Category} not found");

        success &= Enum.TryParse(req.Accessibility, out Accessibility accessibility);
        if (!success)
            return Result.NotFound($"Accessibility with value {req.Accessibility} not found");

        var e = new Event(category, accessibility, req.Name, req.Published);


        if (req.Location is not null)
            e.Location = req.Location;

        if (req.Start is not null)
            e.Start = e.Start;

        if (req.End is not null)
            e.End = e.End;

        if (req.Description is not null)
            e.Description = req.Description;

        e.ICal = req.ICal;

        if (req.BannerUrl is not null)
        {
            var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.BannerUrl, cancellationToken: ct);
            var image = i ?? new Image(req.BannerUrl!);
            e.Banner = image;
        }

        if (req.SponsorIds is not null)
        {
            e.Sponsors = await dbContext.Sponsors.Where(s => req.SponsorIds.Contains(s.Id)).ToListAsync(cancellationToken: ct);
        }

        e.EntryFee = req.EntryFee;

        dbContext.Events.Add(e);
        await dbContext.SaveChangesAsync(ct);

        return Result.Success(new EventResponse.PostEvent { Id = e.Id });
    }

    #endregion

    #region Put

    public async Task<Result<EventResponse.PutEvent>> PutEvent(int id, EventRequest.PutEvent req, CancellationToken ct)
    {
        var e = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id, ct);

        if (e is null)
            return Result.NotFound($"Event with id {id} not found");

        if (req.Name is not null)
            e.Name = req.Name;

        if (req.Category is not null)
        {
            var success = Enum.TryParse(req.Category, out Category category);
            if (!success)
                return Result.NotFound($"Category with value {req.Category} not found");
            e.Category = category;
        }

        if (req.Accessibility is not null)
        {
            var success = Enum.TryParse(req.Accessibility, out Accessibility accessibility);
            if (!success)
                return Result.NotFound($"Accessibility with value {req.Accessibility} not found");
            e.Accessibility = accessibility;
        }

        if (req.Location is not null)
            e.Location = req.Location;

        if (req.Start is not null)
            e.Start = e.Start;

        if (req.End is not null)
            e.End = e.End;

        if (req.Description is not null)
            e.Description = req.Description;

        e.ICal = req.ICal;

        if (req.BannerUrl is not null)
        {
            var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.BannerUrl, cancellationToken: ct);
            var image = i ?? new Image(req.BannerUrl!);
            e.Banner = image;
        }

        if (req.SponsorIds is not null)
        {
            e.Sponsors = await dbContext.Sponsors.Where(s => req.SponsorIds.Contains(s.Id)).ToListAsync(cancellationToken: ct);
        }

        e.EntryFee = req.EntryFee;

        if (req.Published is not null)
            e.Published = req.Published.Value;

        await dbContext.SaveChangesAsync(ct);

        return Result.Success(new EventResponse.PutEvent { Id = e.Id });
    }

    #endregion

    #region Delete

    public async Task<Result<EventResponse.DeleteEvent>> DeleteEvent(int id, CancellationToken ct)
    {
        var e = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id, ct);

        if (e is null)
            return Result.NotFound($"Event with id {id} not found");

        dbContext.Remove(e);
        await dbContext.SaveChangesAsync(ct);

        return Result.Success(new EventResponse.DeleteEvent { Id = e.Id });
    }

    #endregion
}