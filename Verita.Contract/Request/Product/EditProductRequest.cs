using Microsoft.AspNetCore.Http;
using Verita.Common.Enums;

namespace Verita.Contract.Request.Product
{
    public class EditProductRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public IFormFile? MainImage { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;

        public IFormFile? BackgroundImage { get; set; }
        public string BackgroundImageUrl { get; set; } = string.Empty;
        public Language LanguageId { get; set; }
        public List<EditProductCardRequest>? ProductCards { get; set; }
        public List<EditProductOrderItemRequest>? ProductOrderItems { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
