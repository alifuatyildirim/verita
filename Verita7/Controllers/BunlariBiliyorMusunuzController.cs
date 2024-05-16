using Microsoft.AspNetCore.Mvc;
using Verita.Application.BasindaBizService;
using Verita.Application.BunlariBiliyorMusunuzService;
using Verita.Application.ProductService;
using Verita.Common.Enums;

namespace Verita7.Controllers
{
    public class BunlariBiliyorMusunuzController : Controller
    {
        private readonly IPageService pageService;
        private readonly IBunlariBiliyorMusunuzService bunlariBiliyorMusunuzService;  

        public BunlariBiliyorMusunuzController(IBunlariBiliyorMusunuzService bunlariBiliyorMusunuzService, IPageService pageService)
        {
            this.bunlariBiliyorMusunuzService = bunlariBiliyorMusunuzService;
            this.pageService = pageService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.PageCategories = await this.pageService.GetPagesByCategoryAsync(PageCategory.MerakEttikleriniz);
            var bunlariBiliyorMusunuz = await this.bunlariBiliyorMusunuzService.GetBunlariBiliyorMusunuzListAsync();
            return View(bunlariBiliyorMusunuz);
        }
    }
}
