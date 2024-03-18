using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Verita.Contract.Request.Product
{
    public class AddProductOrderItemRequest
    { 
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int ProductId{ get; set; } 
        public string CreatedBy { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
    }
}
