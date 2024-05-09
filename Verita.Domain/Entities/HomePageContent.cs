using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verita.Common.Enums;

namespace Verita.Domain.Entities
{
    public class HomePageContent : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public HomePageContentType ContentType { get; set; }
    }
}
