using Mimisbrunnr.Models.Constants;

namespace Mimisbrunnr.Contracts.Responses
{
    public class EventListItem
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public EventType Type { get; set; }
        public string BannerUrl { get; set; }
        public DateTime VisibilityDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
