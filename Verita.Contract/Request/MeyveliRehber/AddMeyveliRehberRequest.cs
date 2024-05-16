using Microsoft.AspNetCore.Http;
using Verita.Common.Enums;

namespace Verita.Contract.Request.MeyveliRehber
{
    public class AddMeyveliRehberRequest
    {
        public string Name { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
        public IFormFile? File { get; set; }
        public string Link { get; set; } = string.Empty;
        public MeyveliRehberType MeyveliRehberType { get; set; }
        public int SortOrder { get; set; }
        public Language LanguageId { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
    }
}
