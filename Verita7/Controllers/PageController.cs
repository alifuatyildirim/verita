using Microsoft.AspNetCore.Mvc;
using Verita.Application.ProductService;

namespace Verita7.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageService pageService;  

        public PageController(IPageService pageService)
        {
            this.pageService = pageService; 

        }
        public async Task<IActionResult> Index(int pageId)
        { 
            var page = await this.pageService.GetPageAsync(pageId);  
            return View(page);
        }
    }
}
