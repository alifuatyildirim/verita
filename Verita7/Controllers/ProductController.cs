using Microsoft.AspNetCore.Mvc;
using Verita.Application.ProductService;

namespace Verita7.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService; 
        private readonly ICategoryService categoryService; 

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;

        }
        public async Task<IActionResult> Index(int productId)
        {
            ViewBag.Categories = await this.categoryService.GetCategoriesAsync();
            productId = 4;
            var product = await this.productService.GetProductAsync(productId);
            var productList = await this.productService.GetProductByCategoryIdAsync(product.CategoryId);
            ViewBag.Products = productList;
            return View(product);
        }
    }
}
