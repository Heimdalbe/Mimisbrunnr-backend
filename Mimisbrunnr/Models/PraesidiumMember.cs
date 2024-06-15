namespace Mimisbrunnr.Models
{
    public class PraesidiumMember: ModelBase
    {
        public PraesidiumFunction Function { get; set; }
        public PraesidiumYear Year { get; set; }
        public string PictureUrl { get; set; }
        public string Name { get; set; }
        // TODO Add fun facts & contact?

        public PraesidiumMember()
        {
        }
    }
}
