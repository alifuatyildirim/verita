namespace Verita.Domain.Entities
{
    public class Hakkimizda : BaseEntity
    { 
        public string BackgroundImageUrl { get; set; } 
        public string Title1 { get; set; }
        public string Description1 { get; set; }
        public string ImageUrl1 { get; set; }
        public string Title2 { get; set; }
        public string Description2 { get; set; }
        public string ImageUrl2 { get; set; }
        public string Title3 { get; set; }
        public string Description3 { get; set; }
        public int SortOrder { get; set; }
    }
}
