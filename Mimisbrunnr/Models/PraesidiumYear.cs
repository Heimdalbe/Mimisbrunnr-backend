namespace Mimisbrunnr.Models
{
    public class PraesidiumYear: ModelBase
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public PraesidiumYear() { }
    }
}
