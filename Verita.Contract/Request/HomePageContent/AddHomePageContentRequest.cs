using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using Verita.Common.Enums;

namespace Verita.Contract.Request.HomePageContent
{
    public class AddHomePageContentRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public HomePageContentType ContentType { get; set; }
        public IFormFile? MainImage { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
         
    }
}
