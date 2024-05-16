using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using Verita.Common.Enums;

namespace Verita.Contract.Request.Hakkimizda
{
    public class AddHakkimizdaRequest
    {
        public string BackgroundImageUrl { get; set; } = string.Empty;
        public string Title1 { get; set; } = string.Empty;
        public string Description1 { get; set; } = string.Empty;
        public string ImageUrl1 { get; set; } = string.Empty;
        public string Title2 { get; set; } = string.Empty;
        public string Description2 { get; set; } = string.Empty;
        public string ImageUrl2 { get; set; } = string.Empty;
        public string Title3 { get; set; } = string.Empty;
        public string Description3 { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public IFormFile? Image1 { get; set; }
        public IFormFile? Image2 { get; set; }
        public IFormFile? BackgroundImage { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;

    }
}
