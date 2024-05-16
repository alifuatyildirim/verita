using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Verita.Application;
using Verita.Application.BasindaBizService;
using Verita.Application.HomePageSliderService;
using Verita.Application.BunlariBiliyorMusunuzService;
using Verita.Application.ProductService;
using Verita.Contract.Request.BasindaBiz;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageContent;
using Verita.Contract.Request.HomePageSlider;
using Verita.Contract.Request.BunlariBiliyorMusunuz;

namespace AdminLTE.Controllers
{
    [Authorize]
    public class BunlariBiliyorMusunuzController : Controller
    {
        private readonly IUserClaimService userClaimService; 
        private readonly IBunlariBiliyorMusunuzService BunlariBiliyorMusunuzService; 
        public BunlariBiliyorMusunuzController(IUserClaimService userClaimService, IBunlariBiliyorMusunuzService BunlariBiliyorMusunuzService)
        {
            this.userClaimService = userClaimService;
            this.BunlariBiliyorMusunuzService = BunlariBiliyorMusunuzService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var homepageSliders = await this.BunlariBiliyorMusunuzService.GetBunlariBiliyorMusunuzListAsync();
            return View(homepageSliders);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var content = await this.BunlariBiliyorMusunuzService.GetBunlariBiliyorMusunuzAsync(id);
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
            var content = await this.BunlariBiliyorMusunuzService.GetBunlariBiliyorMusunuzAsync(id);

            return View(new EditBunlariBiliyorMusunuzRequest
            { 
                Id = content.Id,
                Title = content.Title,
                Description = content.Description,
                SortOrder = content.SortOrder
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddBunlariBiliyorMusunuzRequest content)
        { 
            if (ModelState.IsValid)
            {
                
                await this.BunlariBiliyorMusunuzService.AddBunlariBiliyorMusunuzAsync(content);
                return RedirectToAction("Index");
            }
            return View(content);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBunlariBiliyorMusunuzRequest content)
        {
            if (ModelState.IsValid)
            { 

                await this.BunlariBiliyorMusunuzService.UpdateBunlariBiliyorMusunuzAsync(content);
                return RedirectToAction("Index");
            }
            return View(content);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.BunlariBiliyorMusunuzService.DeleteBunlariBiliyorMusunuzAsync(id);
            return RedirectToAction("Index");
        }


    }
}
