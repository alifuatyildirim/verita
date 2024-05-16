using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Verita.Application;
using Verita.Application.BasindaBizService;
using Verita.Application.HomePageSliderService;
using Verita.Application.HakkimizdaTimeLineService;
using Verita.Application.ProductService;
using Verita.Contract.Request.BasindaBiz;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageContent;
using Verita.Contract.Request.HomePageSlider;

namespace AdminLTE.Controllers
{
    [Authorize]
    public class HakkimizdaTimeLineController : Controller
    {
        private readonly IUserClaimService userClaimService; 
        private readonly IHakkimizdaTimeLineService HakkimizdaTimeLineService; 
        public HakkimizdaTimeLineController(IUserClaimService userClaimService, IHakkimizdaTimeLineService HakkimizdaTimeLineService)
        {
            this.userClaimService = userClaimService;
            this.HakkimizdaTimeLineService = HakkimizdaTimeLineService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var homepageSliders = await this.HakkimizdaTimeLineService.GetHakkimizdaTimeLineListAsync();
            return View(homepageSliders);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var content = await this.HakkimizdaTimeLineService.GetHakkimizdaTimeLineAsync(id);
            return View(content);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var content = await this.HakkimizdaTimeLineService.GetHakkimizdaTimeLineAsync(id);

            return View(new EditHakkimizdaTimeLineRequest
            { 
                Id = content.Id,
                Year = content.Year,
                Description = content.Description,
                SortOrder = content.SortOrder
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddHakkimizdaTimeLineRequest content)
        { 
            if (ModelState.IsValid)
            {
                
                await this.HakkimizdaTimeLineService.AddHakkimizdaTimeLineAsync(content);
                return RedirectToAction("Index");
            }
            return View(content);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditHakkimizdaTimeLineRequest content)
        {
            if (ModelState.IsValid)
            { 

                await this.HakkimizdaTimeLineService.UpdateHakkimizdaTimeLineAsync(content);
                return RedirectToAction("Index");
            }
            return View(content);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.HakkimizdaTimeLineService.DeleteHakkimizdaTimeLineAsync(id);
            return RedirectToAction("Index");
        }


    }
}
