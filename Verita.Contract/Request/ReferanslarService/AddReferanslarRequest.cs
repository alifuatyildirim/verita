using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using Verita.Common.Enums;

namespace Verita.Contract.Request.Referanslar
{
    public class AddReferanslarRequest
    {
        public string Title { get; set; } 
        public int SortOrder { get; set; } 
        public IFormFile? MainImage { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
         
    }
}
