using Mimisbrunnr.Models.Constants;
using Mimisbrunnr.Models;

namespace Mimisbrunnr.Contracts.Responses
{
    public class EventDetailItem
    {
        public Guid Guid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }
        public EventType Type { get; set; }
        public string BannerUrl { get; set; }
        public DateTime VisibilityDate { get; set; }
        public string Location { get; set; }

        public DateTime? PostToDiscordDate { get; set; }
        public bool IsPostedToDiscord { get; set; }
        public DiscordWebhook? DiscordWebhook { get; set; }
        public int? DiscordWebhookId { get; set; }
        public string? DiscordDescription { get; set; }

        public string? OwnerName { get; set; }
        public Guid? OwnerGuid { get; set; }
    }
}
