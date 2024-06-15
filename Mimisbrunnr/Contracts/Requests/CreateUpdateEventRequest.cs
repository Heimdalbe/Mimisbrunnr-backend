using Mimisbrunnr.Models.Constants;

namespace Mimisbrunnr.Contracts.Requests
{
    public class CreateUpdateEventRequest
    {
        /// <summary>
        /// Guid of the Event to change. Only necessary when updating
        /// </summary>
        public Guid? Guid { get; set; }
        /// <summary>
        /// Starting datetime
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Ending datetime
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Name of the Event
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Short description of the Event for overview display
        /// </summary>
        public string Intro { get; set; }
        /// <summary>
        /// Full description of the event
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Type of Event for optional filtering
        /// </summary>
        public EventType Type { get; set; }
        /// <summary>
        /// Url for the banner
        /// </summary>
        public string BannerUrl { get; set; }
        /// <summary>
        /// When this Event should be visible. Check DateTime.Now against this date. If null, DateTime.Now is used as a default so it's immediately visible.
        /// </summary>
        public DateTime? VisibilityDate { get; set; }

        /// <summary>
        /// Settings pertaining to posting the Event to a Discord channel. Null value means you don't want to post it to Discord.
        /// </summary>
        public PostToDiscordSettings? PostToDiscordSettings { get; set; }
        /// <summary>
        /// Person that is responsible for the Event. Easy access for contact or administration. Optional.
        /// </summary>
        public Guid? OwnerGuid { get; set; }
        /// <summary>
        /// Location of the Event
        /// </summary>
        public string Location { get; set; }
    }

    public class PostToDiscordSettings
    {
        /// <summary>
        /// When this Event should be posted. Leave null to post immediately.
        /// </summary>
        public DateTime? PostToDiscordDate { get; set; }

        /// <summary>
        /// What webhook to use. If left null but other values are given, this will delete the scheduled event as a fallback.
        /// </summary>
        public Guid? WebhookGuid { get; set; }
        /// <summary>
        /// Optional text to be used to post to Discord. Will fallback to the full description of the Event.
        /// </summary>
        public string? DiscordDescription { get; set; }
    }
}
