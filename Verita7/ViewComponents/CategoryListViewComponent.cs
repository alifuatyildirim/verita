using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verita.Application.ProductService;
using Verita7.Models;

namespace Verita7.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public CategoryListViewComponent(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new CategoryViewModel
            {
                Products = await productService.GetProductsAsync(),
                Categories = await categoryService.GetCategoriesAsync()
            });
        }
    }
}
