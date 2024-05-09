using Microsoft.AspNetCore.Mvc;
using Verita.Application.ProductService;

namespace Verita7.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageService pageService;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public PageController(IPageService pageService, IProductService productService, ICategoryService categoryService)
        {
            this.pageService = pageService; 
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index(int pageId, bool isPage=false)
        { 
            var page = await this.pageService.GetPageAsync(pageId);
            ViewBag.IsPage = isPage;
            if (isPage)
            {
                ViewBag.Categories = await this.categoryService.GetCategoriesAsync();
            }
            ViewBag.PageCategories = await this.pageService.GetPagesByCategoryAsync(page!.PageCategory);
            return View(page);
        }
    }
}
