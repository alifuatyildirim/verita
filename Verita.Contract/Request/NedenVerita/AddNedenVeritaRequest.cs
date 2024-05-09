using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using Verita.Common.Enums;

namespace Verita.Contract.Request.HomePageContent
{
    public class AddNedenVeritaRequest
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Description { get; set; } 
        public int SortOrder { get; set; } 
         
    }
}
