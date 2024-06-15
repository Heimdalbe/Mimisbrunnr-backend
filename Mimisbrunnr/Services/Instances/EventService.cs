using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Contracts.Requests;
using Mimisbrunnr.Contracts.Responses;
using Mimisbrunnr.Data;
using Mimisbrunnr.Mappers;
using Mimisbrunnr.Models;
using Mimisbrunnr.Services.Interfaces;

namespace Mimisbrunnr.Services.Instances
{
    public class EventService : IEventService
    {
        private readonly Context _context;
        private readonly IJobService _jobService;

        public EventService(Context context, IJobService jobService)
        {
            _context = context;
            _jobService = jobService;
        }

        public async Task<Guid> CreateUpdateEvent(CreateUpdateEventRequest request)
        {
            // Create
            if (!request.Guid.HasValue)
            {
                var mappedEvent = new CreateUpdateEventMapper().CreateUpdateEventRequestToEvent(request);
                var guid = Guid.NewGuid();
                mappedEvent.Guid = guid;
                var owner = await _context.PraesidiumMember.SingleOrDefaultAsync(p => p.Guid == request.OwnerGuid);
                if (owner != null)
                    mappedEvent.OwnerId = owner.Id;

                _context.Add(mappedEvent);
                await _context.SaveChangesAsync();
                if (request.PostToDiscordSettings != null)
                    await _jobService.ScheduleEventPostToDiscord(guid, request.PostToDiscordSettings.WebhookGuid, request.PostToDiscordSettings.PostToDiscordDate);
                return guid;
            }
            // Update
            var @event = await _context.Event.SingleOrDefaultAsync(e => e.Guid == request.Guid) ?? throw new ArgumentException($"No event found with Guid {request.Guid}");
            _ = await UpdateJobIfNeeded(request, @event);
            @event = await MapDtoToExistingEvent(request, @event);
            await _context.SaveChangesAsync();
            return @event.Guid;
        }

        public async Task<List<EventListItem>> GetAll()
        {
            var events = await _context.Event.AsNoTracking().OrderBy(e => e.StartDate).ToListAsync();
            var mapper = new EventListItemMapper();
            return events.Select(mapper.EventToEventListItem).ToList();
        }

        public async Task<EventDetailItem> Get(Guid guid)
        {
            var _event = await _context.Event.SingleOrDefaultAsync(e => e.Guid == guid) ?? throw new ArgumentException($"Event with Guid ");
            return new EventDetailItemMapper().EventToEventDetailItem(_event);
        }

        #region Privs

        private async Task<bool> UpdateJobIfNeeded(CreateUpdateEventRequest request, Event @event)
        {
            if (@event.IsPostedToDiscord)
                return true;

            var guid = @event.Guid;

            // We didn't schedule previously and we shouldn't change that either
            if (request.PostToDiscordSettings == null && @event.JobId == null)
                return true;

            // Clean the scheduled job
            if (request.PostToDiscordSettings == null && @event.JobId != null)
                return await _jobService.ScheduleEventPostToDiscord(guid, Guid.Empty, null);

            var settings = request.PostToDiscordSettings!;

            // At this point, we're sure PostToDiscordSettings is not null and we do want to schedule it
            // If the posting was already scheduled, we only reschedule if we changed the date
            // For Event, if the stored Date is null, it was either posted immediately and IsPostedToDiscord is true or we didn't schedule anything yet (in which case JobId is null and we already account for this)

            if (@event.JobId == null || @event.PostToDiscordDate != settings.PostToDiscordDate)
                return await _jobService.ScheduleEventPostToDiscord(guid, settings.WebhookGuid, settings.PostToDiscordDate, request.Description);
            return true;
        }

        private async Task<Event> MapDtoToExistingEvent(CreateUpdateEventRequest request, Event @event)
        {
            @event.StartDate = request.StartDate;
            @event.EndDate = request.EndDate;
            @event.Name = request.Name;
            @event.Description = request.Description;
            @event.Type = request.Type;
            @event.BannerUrl = request.BannerUrl;
            @event.Intro = request.Intro;
            @event.VisibilityDate = request.VisibilityDate ?? DateTime.Now;
            @event.Owner = await _context.PraesidiumMember.SingleOrDefaultAsync(p => p.Guid == request.Guid);
            @event.Location = request.Location;

            return @event;
        }

        #endregion
    }
}
