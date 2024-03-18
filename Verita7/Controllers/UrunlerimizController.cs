using Microsoft.AspNetCore.Mvc;
using Verita.Application.ProductService;

namespace Verita7.Controllers
{
    public class UrunlerimizController : Controller
    {
        private readonly IProductService productService; 
        private readonly ICategoryService categoryService; 

        public UrunlerimizController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;

        }
        public async Task<IActionResult> Index(int categoryId)
        {
            ViewBag.Categories = await this.categoryService.GetCategoriesAsync();
            var productList = await this.productService.GetProductByCategoryIdAsync(categoryId);
            return View(productList);
        }
    }
}
