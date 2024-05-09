using Microsoft.AspNetCore.Http;
using Verita.Common.Enums;

namespace Verita.Contract.Request.HomePageContent
{
    public class EditNedenVeritaRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
    }
}
