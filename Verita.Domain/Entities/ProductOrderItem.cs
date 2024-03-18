using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verita.Domain.Entities
{
    public class ProductOrderItem : BaseEntity
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public virtual Product Product { get; set; }
    }
}
