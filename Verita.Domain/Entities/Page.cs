namespace Verita.Domain.Entities
{
    public class Page : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BackgroundUrl { get; set; } = string.Empty;  
        public virtual List<PageImage> PageImages { get; set; }
    }
}
