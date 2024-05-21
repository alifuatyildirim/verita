using Microsoft.AspNetCore.Mvc;
using Verita.Application.BasindaBizService;
using Verita.Application.ProductService;
using Verita.Common.Enums;

namespace Verita7.Controllers
{
    public class BasindaBizController : Controller
    {
        private readonly IBasindaBizService basindaBizService;

        public BasindaBizController(IBasindaBizService basindaBizService)
        {
            this.basindaBizService = basindaBizService;

        }
        public async Task<IActionResult> Index(int productId)
        {
            var basindaBiz = await this.basindaBizService.GetBasindaBizListAsync();
            List<int> years = basindaBiz
                .Select(x => x.DateOfPublication.Year)
                .Distinct()
                .OrderByDescending(year => year)
                .ToList();

            ViewBag.Years = years;
            return View(basindaBiz);
        }
    }
}
