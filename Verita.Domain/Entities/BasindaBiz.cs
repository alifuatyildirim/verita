using Verita.Common.Enums;

namespace Verita.Domain.Entities
{
    public class BasindaBiz : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Resource { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public BasindaBizContentType ContentType{ get; set; }
        public LabelType LabelType{ get; set; }
        public DateTime DateOfPublication { get; set; }
        public int SortOrder { get; set; }  
    }
}
