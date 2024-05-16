using Microsoft.AspNetCore.Http;
using Verita.Common.Enums;

namespace Verita.Contract.Request.BasindaBiz
{
    public class AddBasindaBizRequest
    {
        public string Name { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public Language LanguageId { get; set; }
        public IFormFile? Image { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string Resource { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public BasindaBizContentType ContentType { get; set; }
        public LabelType LabelType { get; set; }
        public string ImageUrl { get; set; } = string.Empty; 
        public string CreatedBy { get; set; } = string.Empty; 
    }
}
