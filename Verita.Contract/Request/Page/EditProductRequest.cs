using Microsoft.AspNetCore.Http;
using Verita.Common.Enums;

namespace Verita.Contract.Request.Product
{
    public class EditPageRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
        public IFormFile? BackgroundImage { get; set; } 
        public string BackgroundUrl { get; set; } = string.Empty;
        public Language LanguageId { get; set; }
        public List<EditPageImageRequest>? PageImages { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
