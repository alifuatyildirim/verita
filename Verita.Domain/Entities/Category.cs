namespace Verita.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string MainImage { get; set; } = string.Empty;
        public string BackgroundImage { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool IsPage { get; set; } = false;
        public int? PageId { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
