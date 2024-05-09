using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Verita.Application;
using Verita.Application.BasindaBizService;
using Verita.Application.HomePageSliderService;
using Verita.Application.NedenVeritaService;
using Verita.Application.ProductService;
using Verita.Contract.Request.BasindaBiz;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageContent;
using Verita.Contract.Request.HomePageSlider;

namespace AdminLTE.Controllers
{
    [Authorize]
    public class NedenVeritaController : Controller
    {
        private readonly IUserClaimService userClaimService; 
        private readonly INedenVeritaService nedenVeritaService; 
        public NedenVeritaController(IUserClaimService userClaimService, INedenVeritaService nedenVeritaService)
        {
            this.userClaimService = userClaimService;
            this.nedenVeritaService = nedenVeritaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var homepageSliders = await this.nedenVeritaService.GetNedenVeritaListAsync();
            return View(homepageSliders);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var content = await this.nedenVeritaService.GetNedenVeritaAsync(id);
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
            var content = await this.nedenVeritaService.GetNedenVeritaAsync(id);

            return View(new EditNedenVeritaRequest
            { 
                Id = content.Id,
                Title = content.Title,
                Description = content.Description,
                SortOrder = content.SortOrder
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddNedenVeritaRequest content)
        { 
            if (ModelState.IsValid)
            {
                
                await this.nedenVeritaService.AddNedenVeritaAsync(content);
                return RedirectToAction("Index");
            }
            return View(content);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditNedenVeritaRequest content)
        {
            if (ModelState.IsValid)
            { 

                await this.nedenVeritaService.UpdateNedenVeritaAsync(content);
                return RedirectToAction("Index");
            }
            return View(content);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.nedenVeritaService.DeleteNedenVeritaAsync(id);
            return RedirectToAction("Index");
        }


    }
}
