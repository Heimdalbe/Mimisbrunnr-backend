namespace Mimisbrunnr.Models
{
    public class Album: ModelBase
    {
        public string Name { get; set; }

        // Optionally linked to Event
        public int? EventId { get; set; }
        public Event Event { get; set; }

        public Album() { }
    }
}
