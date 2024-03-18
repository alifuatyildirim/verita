namespace Verita.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string MainImageUrl { get; set; } = string.Empty;
        public string BackgroundImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<ProductCard> ProductCards { get; set; }
        public virtual List<ProductOrderItem> ProductOrderItems { get; set; }
    }
}
