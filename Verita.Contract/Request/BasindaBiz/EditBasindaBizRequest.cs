using Microsoft.AspNetCore.Http;
using Verita.Common.Enums;

namespace Verita.Contract.Request.BasindaBiz
{
    public class EditBasindaBizRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public Language LanguageId { get; set; }
        public IFormFile? Image { get; set; }
        public DateTime DateOfPublication { get; set; }

        public string ImageUrl { get; set; } = string.Empty; 
        public string CreatedBy { get; set; } = string.Empty; 
    }
}
