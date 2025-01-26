using Mimmisbrunnr.Api.DTOs.Common;
using Mimmisbrunnr.Domain.Activities;
using Mimmisbrunnr.Domain.Common;

namespace Mimmisbrunnr.Api.DTOs.Activities
{
    public class ActivityOverviewDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ImageDTO Banner { get; set; }
        public Category Category { get; set; }
    }
}
