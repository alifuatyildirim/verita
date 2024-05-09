using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Verita.Application;
using Verita.Application.BasindaBizService;
using Verita.Application.HomePageSliderService;
using Verita.Application.ProductService;
using Verita.Contract.Request.BasindaBiz;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageSlider;

namespace AdminLTE.Controllers
{
    [Authorize]
    public class HomePageSliderController : Controller
    {
        private readonly IUserClaimService userClaimService; 
        private readonly IHomePageSliderService homePageSliderService; 
        public HomePageSliderController(IUserClaimService userClaimService, IHomePageSliderService homePageSliderService)
        {
            this.userClaimService = userClaimService;
            this.homePageSliderService = homePageSliderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var homepageSliders = await this.homePageSliderService.GetHomePageSliderListAsync();
            return View(homepageSliders);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var slider = await this.homePageSliderService.GetHomePageSliderAsync(id);
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
            var slider = await this.homePageSliderService.GetHomePageSliderAsync(id);

            return View(new EditHomePageSliderRequest
            { 
                Id = slider.Id,
                Name = slider.Name,
                Description = slider.Description,
                Link = slider.Link,
                MainImageUrl = slider.ImageUrl,
                SortOrder = slider.SortOrder,
                
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddHomePageSliderRequest slider)
        { 
            if (ModelState.IsValid)
            {
                if (slider.MainImage != null)
                {
                    slider.MainImageUrl = await this.homePageSliderService.SaveImageAsync(slider.MainImage.OpenReadStream(), slider.MainImage.FileName);
                }
                await this.homePageSliderService.AddHomePageSliderAsync(slider);
                return RedirectToAction("Index");
            }
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditHomePageSliderRequest slider)
        {
            if (ModelState.IsValid)
            {
                if (slider.MainImage != null)
                {
                    slider.MainImageUrl = await this.homePageSliderService.SaveImageAsync(slider.MainImage.OpenReadStream(), slider.MainImage.FileName);
                }

                await this.homePageSliderService.UpdateHomePageSliderAsync(slider);
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.homePageSliderService.DeleteHomePageSliderAsync(id);
            return RedirectToAction("Index");
        }


    }
}
