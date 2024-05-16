using Microsoft.AspNetCore.Mvc;
using Verita.Application.HakkimizdaService;
using Verita.Application.HakkimizdaTimeLineService;

namespace Verita7.Controllers
{
    public class HakkimizdaController : Controller
    {
        private readonly IHakkimizdaService hakkimizdaService;
        private readonly IHakkimizdaTimeLineService hakkimizdaTimeLineService;

        public HakkimizdaController(IHakkimizdaService hakkimizdaService, IHakkimizdaTimeLineService hakkimizdaTimeLineService)
        {
            this.hakkimizdaService = hakkimizdaService;
            this.hakkimizdaTimeLineService = hakkimizdaTimeLineService;
        }
        public async Task<IActionResult> Index()
        {
            var hakkimizda = await hakkimizdaService.GetHakkimizdaListAsync();
            ViewBag.TimeLines = await hakkimizdaTimeLineService.GetHakkimizdaTimeLineListAsync();
            return View(hakkimizda?.FirstOrDefault());
        }
    }
}
