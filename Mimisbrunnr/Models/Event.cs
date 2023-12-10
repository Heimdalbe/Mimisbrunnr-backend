using Mimisbrunnr.Models.Constants;

namespace Mimisbrunnr.Models
{
    public class Event: ModelBase
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }
        public EventType Type { get; set; }
        public string BannerUrl { get; set; }
        public DateTime VisibilityDate { get; set; }

        /// <summary>
        /// If this event has already been scheduled, this will be filled in and is used to retrieve the job if a reschedule is needed
        /// </summary>
        public string? JobId { get; set; }
        public DateTime? PostToDiscordDate { get; set; }
        public bool IsPostedToDiscord { get; set; }
        public DiscordWebhook? DiscordWebhook { get; set; }
        public int? DiscordWebhookId { get; set; }
        public string? DiscordDescription {  get; set; }

        public PraesidiumMember? Owner { get; set; }
        public int? OwnerId { get; set; }

        public Event() { }
    }
}
