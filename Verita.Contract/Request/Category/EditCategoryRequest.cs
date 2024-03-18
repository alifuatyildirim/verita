using Microsoft.AspNetCore.Http;
using Verita.Common.Enums;

namespace Verita.Contract.Request.Category
{
    public class EditCategoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public Language LanguageId { get; set; }
        public IFormFile? MainImage { get; set; }

        public string MainImageUrl { get; set; } = string.Empty;

        public IFormFile? BackgroundImage { get; set; }
        public string BackgroundImageUrl { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
    }
}
