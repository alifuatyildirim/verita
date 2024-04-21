namespace Verita.Domain.Entities
{
    public class BasindaBiz : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime DateOfPublication { get; set; }
        public int SortOrder { get; set; }  
    }
}
