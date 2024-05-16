using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using Verita.Common.Enums;

namespace Verita.Contract.Request.HomePageContent
{
    public class AddNedenVeritaRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SortOrder { get; set; }

    }
}
