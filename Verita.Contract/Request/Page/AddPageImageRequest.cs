using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Verita.Contract.Request.Product
{
    public class AddPageImageRequest
    { 
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int PageId{ get; set; } 
        public string CreatedBy { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
    }
}
