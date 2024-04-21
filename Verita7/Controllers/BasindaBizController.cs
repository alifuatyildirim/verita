using Microsoft.AspNetCore.Mvc;
using Verita.Application.BasindaBizService;
using Verita.Application.ProductService;

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
            return View(basindaBiz);
        }
    }
}
