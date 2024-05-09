using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Verita.Application;
using Verita.Application.BasindaBizService;
using Verita.Application.HomePageSliderService;
using Verita.Application.ProductService;
using Verita.Contract.Request.BasindaBiz;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageContent;
using Verita.Contract.Request.HomePageSlider;

namespace AdminLTE.Controllers
{
    [Authorize]
    public class HomePageContentController : Controller
    {
        private readonly IUserClaimService userClaimService; 
        private readonly IHomePageContentService homePageContentService; 
        public HomePageContentController(IUserClaimService userClaimService, IHomePageContentService homePageContentService)
        {
            this.userClaimService = userClaimService;
            this.homePageContentService = homePageContentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var homepageSliders = await this.homePageContentService.GetHomePageContentListAsync();
            return View(homepageSliders);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var slider = await this.homePageContentService.GetHomePageContentAsync(id);
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
            var content = await this.homePageContentService.GetHomePageContentAsync(id);

            return View(new EditHomePageContentRequest
            { 
                Id = content.Id,
                Title = content.Title,
                Description = content.Description,
                Link = content.Link,
                MainImageUrl = content.Image,
                ContentType = content.ContentType,
                
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddHomePageContentRequest content)
        { 
            if (ModelState.IsValid)
            {
                if (content.MainImage != null)
                {
                    content.MainImageUrl = await this.homePageContentService.SaveImageAsync(content.MainImage.OpenReadStream(), content.MainImage.FileName);
                }
                await this.homePageContentService.AddHomePageContentAsync(content);
                return RedirectToAction("Index");
            }
            return View(content);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditHomePageContentRequest content)
        {
            if (ModelState.IsValid)
            {
                if (content.MainImage != null)
                {
                    content.MainImageUrl = await this.homePageContentService.SaveImageAsync(content.MainImage.OpenReadStream(), content.MainImage.FileName);
                }

                await this.homePageContentService.UpdateHomePageContentAsync(content);
                return RedirectToAction("Index");
            }
            return View(content);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.homePageContentService.DeleteHomePageContentAsync(id);
            return RedirectToAction("Index");
        }


    }
}
