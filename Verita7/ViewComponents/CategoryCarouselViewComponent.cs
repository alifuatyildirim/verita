using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verita.Application.ProductService;
using Verita.Common.Enums;
using Verita7.Models;

namespace Verita7.ViewComponents
{
    public class CategoryCarouselViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService; 

        public CategoryCarouselViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService; 

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new CategoryViewModel
            {
                Categories = await categoryService.GetCategoriesAsync()
            });
        }
    }
}
