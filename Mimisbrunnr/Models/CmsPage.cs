namespace Mimisbrunnr.Models
{
    public class CmsPage: ModelBase
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsVisible { get; set; }

        public CmsPage() { }
    }
}
