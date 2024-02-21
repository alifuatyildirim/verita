using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verita.Domain.Entities
{
    public class PageImage:BaseEntity
    {
        public int PageId { get; set; } 
        public string Image { get; set; } = string.Empty;
        public virtual Page Page { get; set; }
    }
}
