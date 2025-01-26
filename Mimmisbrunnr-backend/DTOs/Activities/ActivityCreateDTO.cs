using Mimmisbrunnr.Api.DTOs.Common;
using Mimmisbrunnr.Domain.Activities;

namespace Mimmisbrunnr.Api.DTOs.Activities
{
    public class ActivityCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ImageDTO Banner { get; set; }
        public LocationCreateDTO Location { get; set; }
        public Category Category { get; set; }
        public Accessibility Accessibility { get; set; }
    }
}
