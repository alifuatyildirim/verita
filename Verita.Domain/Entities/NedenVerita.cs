using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verita.Common.Enums;

namespace Verita.Domain.Entities
{
    public class NedenVerita : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
    }
}
