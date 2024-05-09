using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Verita.Application;
using Verita.Application.BasindaBizService;
using Verita.Application.HomePageSliderService;
using Verita.Application.ProductService;
using Verita.Contract.Request.BasindaBiz;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.Referanslar;
using Verita.Contract.Request.HomePageSlider;

namespace AdminLTE.Controllers
{
    [Authorize]
    public class ReferanslarController : Controller
    {
        private readonly IUserClaimService userClaimService;
        private readonly IReferanslarService referanslarService;
        public ReferanslarController(IUserClaimService userClaimService, IReferanslarService referanslarService)
        {
            this.userClaimService = userClaimService;
            this.referanslarService = referanslarService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var homepageSliders = await this.referanslarService.GetReferanslarListAsync();
            return View(homepageSliders);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var slider = await this.referanslarService.GetReferanslarAsync(id);
            return View(slider);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var content = await this.referanslarService.GetReferanslarAsync(id);

            return View(new EditReferanslarRequest
            {
                Id = content.Id,
                Title = content.Title, 
                MainImageUrl = content.Image,
                SortOrder= content.SortOrder,

            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddReferanslarRequest content)
        {
            if (ModelState.IsValid)
            {
                if (content.MainImage != null)
                {
                    content.MainImageUrl = await this.referanslarService.SaveImageAsync(content.MainImage.OpenReadStream(), content.MainImage.FileName);
                }
                await this.referanslarService.AddReferanslarAsync(content);
                return RedirectToAction("Index");
            }
            return View(content);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditReferanslarRequest content)
        {
            if (ModelState.IsValid)
            {
                if (content.MainImage != null)
                {
                    content.MainImageUrl = await this.referanslarService.SaveImageAsync(content.MainImage.OpenReadStream(), content.MainImage.FileName);
                }

                await this.referanslarService.UpdateReferanslarAsync(content);
                return RedirectToAction("Index");
            }
            return View(content);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.referanslarService.DeleteReferanslarAsync(id);
            return RedirectToAction("Index");
        }


    }
}
