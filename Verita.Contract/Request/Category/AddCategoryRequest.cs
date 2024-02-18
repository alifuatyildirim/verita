using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verita.Common.Enums;

namespace Verita.Contract.Request.Category
{
    public class AddCategoryRequest
    {
        public string Title { get; set; }
        public int SortOrder { get; set; }
        public Language LanguageId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
