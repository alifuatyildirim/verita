using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verita.Application.ProductService;
using Verita.Common.Enums;
using Verita7.Models;

namespace Verita7.ViewComponents
{
    public class PageListFooterViewComponent : ViewComponent
    {
        private readonly IPageService pageService; 

        public PageListFooterViewComponent(IPageService pageService)
        {
            this.pageService = pageService; 

        }

        public async Task<IViewComponentResult> InvokeAsync(PageCategory pageCategoryId)
        {
            return View(new PageViewModel
            {
                Pages = await pageService.GetPagesByCategoryAsync(pageCategoryId)
            });
        }
    }
}
