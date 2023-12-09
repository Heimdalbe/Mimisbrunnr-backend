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

        public PraesidiumMember Owner { get; set; }
        public int OwnerId { get; set; }


        public Event() { }
    }
}
