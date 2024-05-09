using Microsoft.AspNetCore.Http;
using Verita.Common.Enums;

namespace Verita.Contract.Request.Referanslar
{
    public class EditReferanslarRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int  SortOrder{ get; set; }
        public IFormFile? MainImage { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
    }
}
