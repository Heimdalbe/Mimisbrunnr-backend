using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Domain.Common;
using Mimisbrunnr.Domain.Events;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Common;
using Mimisbrunnr.Shared.Events;
using Mimisbrunnr.Shared.Events.Dtos;
using Mimisbrunnr.Shared.Identity;
using static Mimisbrunnr.Services.Mappers.Mappers;

namespace Mimisbrunnr.Services.Events;

public class EventService(ApplicationDbContext dbContext, ISessionContextProvider sessionContextProvider) : IEventService
{
    #region Get

    public async Task<Result<EventResponse.GetEvents>> GetOpenEvents(QueryRequest.SkipTake req, CancellationToken ct)
    {
        var events = await dbContext.Events
            .Include(e => e.Banner)
            .Where(e => e.Published &&
                        e.Accessibility == Accessibility.OPEN &&
                        e.End >= DateTime.Now
            ).ToListAsync(cancellationToken: ct);

        var dtos = events.Select(ToPublicSimpleDto)
            .Skip(req.Skip)
            .Take(req.Take)
            .OrderBy(e => e.Start)
            .ToList().AsReadOnly();

        return Result.Success(new EventResponse.GetEvents { Events = dtos });
    }

    public async Task<Result<EventResponse.GetEvents>> GetPublishedEvents(QueryRequest.SkipTake req, CancellationToken ct)
    {
        var query = dbContext.Events
            .Include(e => e.Banner)
            .Where(e => e.Published && e.End >= DateTime.Now);

        if (!string.IsNullOrEmpty(req.Categories))
        {
            var categoryList = req.Categories
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => Enum.TryParse<Category>(c, true, out var cat) ? (Category?)cat : null)
                .Where(c => c.HasValue)
                .Select(c => c!.Value)
                .ToList();

            if (categoryList.Count > 0)
                query = query.Where(e => categoryList.Contains(e.Category));
        }

        var events = await query.ToListAsync(cancellationToken: ct);

        var dtos = events.Select(ToPublicSimpleDto)
            .Skip(req.Skip)
            .OrderBy(e => e.Start)
            .Take(req.Take)
            .ToList().AsReadOnly();

        return Result.Success(new EventResponse.GetEvents { Events = dtos });
    }

    public async Task<Result<EventResponse.GetEvents>> GetEvents(CancellationToken ct)
    {
        var events = await dbContext.Events
            .Include(e => e.Banner)
            .ToListAsync(cancellationToken: ct);

        var dtos = events.Select(EventToSimpleDto)
            .OrderBy(e => e.Start)
            .ToList().AsReadOnly();

        return Result.Success(new EventResponse.GetEvents { Events = dtos });
    }

    public async Task<Result<EventDto.Detailed>> GetOpenEvent(int id, CancellationToken ct)
    {
        var e = await dbContext.Events
            .Include(e => e.Banner)
            .Include(e => e.Sponsors)
            .ThenInclude(s => s.Logo)
            .FirstOrDefaultAsync(e => e.Id == id && e.Published, ct);
        
        if (e is null)
            return Result.NotFound($"Event with id {id} not found");
        
        return Result.Success(ToPublicDetailedDto(e));
    }

    public async Task<Result<EventDto.Detailed>> GetPublishedEvent(int id, CancellationToken ct)
    {
        var e = await dbContext.Events
            .Include(e => e.Banner)
            .Include(e => e.Sponsors)
            .ThenInclude(s => s.Logo)
            .FirstOrDefaultAsync(e => e.Id == id && e.Published, ct);

        if (e is null)
            return Result.NotFound($"Event with id {id} not found");
        
        return Result.Success(ToPublicDetailedDto(e));
    }

    public async Task<Result<EventDto.Detailed>> GetEvent(int id, CancellationToken ct)
    {
        var e = await dbContext.Events
            .Include(e => e.Banner)
            .Include(e => e.Sponsors)
            .ThenInclude(s => s.Logo)
            .FirstOrDefaultAsync(e => e.Id == id, ct);

        if (e is null)
            return Result.NotFound($"Event with id {id} not found");

        return Result.Success(EventToDetailedDto(e));
    }

    private EventDto.Simple ToPublicSimpleDto(Event e)
    {
        var dto = EventToSimpleDto(e);
        if (RegistrationAccessError(e) is not null)
            dto.Url = null;
        return dto;
    }

    private EventDto.Detailed ToPublicDetailedDto(Event e)
    {
        var dto = EventToDetailedDto(e);
        dto.RegistrationAccessError = RegistrationAccessError(e);
        if (dto.RegistrationAccessError is not null)
            dto.Url = null;
        return dto;
    }

    private string? RegistrationAccessError(Event e)
    {
        if (string.IsNullOrWhiteSpace(e.Url) || e.Url == "https://heimdal.be")
            return null;

        var roles = EventAllowedRoles(e);
        if (roles.Count == 0)
            return null;

        var user = sessionContextProvider.User;
        var authenticated = user?.Identity?.IsAuthenticated == true;
        var hasPaidMembership = authenticated && user!.IsInRole(AppRoles.Heimie);
        var allowed = authenticated && (user!.IsInRole(AppRoles.Hmdl) || roles.Any(role =>
            user.IsInRole(role) && (role != AppRoles.Schacht && role != AppRoles.Commilitones || hasPaidMembership)));
        if (allowed)
            return null;

        if (authenticated && !hasPaidMembership && roles.Any(role =>
                (role == AppRoles.Schacht || role == AppRoles.Commilitones) && user!.IsInRole(role)))
            return "Je hebt ook de Heimie-rol (betaald lidmaatschap) nodig om je in te schrijven.";

        var audience = string.Join(" of ", roles);
        var membershipNote = roles.Any(role => role is AppRoles.Schacht or AppRoles.Commilitones)
            ? " Voor Schacht of Commilitones is ook Heimie nodig." : "";
        return authenticated
            ? $"Inschrijven voor dit evenement vereist een van deze rollen: {audience}.{membershipNote}"
            : $"Log in om je in te schrijven. Toegelaten rollen: {audience}.{membershipNote}";
    }

    private static Result<List<string>> ResolveAllowedRoles(string? accessibility, List<string>? requested)
    {
        if (requested is null)
        {
            if (!Enum.TryParse(accessibility, out Accessibility value) || !Enum.IsDefined(value))
                return Result.Invalid(new ValidationError { Identifier = "Accessibility", ErrorMessage = "Kies een geldige doelgroep voor het evenement." });
            requested = DefaultEventRoles(value);
        }

        var roles = new List<string>();
        foreach (var name in requested)
        {
            var role = EventRegistrationRoles.All.FirstOrDefault(r => string.Equals(r, name, StringComparison.OrdinalIgnoreCase));
            if (role is null)
                return Result.Invalid(new ValidationError { Identifier = "AllowedRoles", ErrorMessage = "Kies geldige lidmaatschapsrollen voor het evenement." });
            if (!roles.Contains(role))
                roles.Add(role);
        }
        return Result.Success(roles);
    }

    #endregion

    #region Post

    public async Task<Result<EventResponse.PostEvent>> PostEvent(EventRequest.PostEvent req, CancellationToken ct)
    {
        var success = Enum.TryParse(req.Category, out Category category);
        if (!success)
            return Result.NotFound($"Category with value {req.Category} not found");

        var roles = ResolveAllowedRoles(req.Accessibility, req.AllowedRoles);
        if (!roles.IsSuccess)
            return Result.Invalid(roles.ValidationErrors);

        var accessibility = roles.Value.Count == 0 ? Accessibility.OPEN : Accessibility.CLOSED;
        var e = new Event(category, accessibility, req.Name, req.Url, req.Published) { AllowedRoles = roles.Value };


        if (req.Location is not null)
            e.Location = req.Location;

        if (req.Start is not null)
            e.Start = req.Start.Value;

        if (req.End is not null)
            e.End = req.End.Value;

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
        var e = await dbContext.Events
            .Include(e => e.Sponsors)
            .FirstOrDefaultAsync(e => e.Id == id, ct);


        if (e is null)
            return Result.NotFound($"Event with id {id} not found");

        if (req.AllowedRoles is not null || req.Accessibility is not null)
        {
            var roles = ResolveAllowedRoles(req.Accessibility, req.AllowedRoles);
            if (!roles.IsSuccess)
                return Result.Invalid(roles.ValidationErrors);
            e.AllowedRoles = roles.Value;
            e.Accessibility = roles.Value.Count == 0 ? Accessibility.OPEN : Accessibility.CLOSED;
        }

        if (req.Name is not null)
            e.Name = req.Name;

        if (req.Category is not null)
        {
            var success = Enum.TryParse(req.Category, out Category category);
            if (!success)
                return Result.NotFound($"Category with value {req.Category} not found");
            e.Category = category;
        }

        if (req.Location is not null)
            e.Location = req.Location;

        if (req.Start is not null)
            e.Start = req.Start.Value;

        if (req.End is not null)
            e.End = req.End.Value;

        if (req.Description is not null)
            e.Description = req.Description;
        
        if (req.Url is not null)
            e.Url = req.Url;

        e.ICal = req.ICal;

        if (req.BannerUrl is not null)
        {
            var i = await dbContext.Images.FirstOrDefaultAsync(i => i.Url == req.BannerUrl, cancellationToken: ct);
            var image = i ?? new Image(req.BannerUrl!);
            e.Banner = image;
        }

        if (req.SponsorIds is not null)
        {
            var sponsors = await dbContext.Sponsors
                .Where(s => req.SponsorIds.Contains(s.Id))
                .ToListAsync(ct);

            var sponsorsToRemove = e.Sponsors
                .Where(existing => !sponsors.Contains(existing))
                .ToList();

            var sponsorsToAdd = sponsors
                .Where(sponsor => !e.Sponsors.Contains(sponsor))
                .ToList();

            e.RemoveSponsors(sponsorsToRemove);
            e.AddSponsors(sponsorsToAdd);
        }

        e.EntryFee = req.EntryFee;

        if (req.Published is not null)
            e.Publish(req.Published.Value);

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