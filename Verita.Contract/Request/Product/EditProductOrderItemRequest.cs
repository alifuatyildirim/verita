using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verita.Contract.Request.Product
{
    public class EditProductOrderItemRequest
    {
        public int? Id { get; set; }
        public int ProductId{ get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
    }
}
