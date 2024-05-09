using Microsoft.AspNetCore.Http;
using Verita.Common.Enums;

namespace Verita.Contract.Request.HomePageContent
{
    public class EditHomePageContentRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public HomePageContentType ContentType { get; set; }
        public IFormFile? MainImage { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
    }
}
