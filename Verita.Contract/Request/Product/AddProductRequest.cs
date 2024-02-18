using Microsoft.AspNetCore.Http;
using Verita.Common.Enums;

namespace Verita.Contract.Request.Product
{
    public class AddProductRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public IFormFile? MainImage { get; set; }

        public string MainImageUrl { get; set; } = string.Empty;
        public Language LanguageId { get; set; }
        public List<AddProductCardRequest>? ProductCards { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
