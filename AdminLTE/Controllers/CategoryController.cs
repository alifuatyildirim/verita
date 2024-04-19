using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verita.Application;
using Verita.Application.ProductService;
using Verita.Contract.Request.Category;
using Verita.Domain.Entities;

namespace Verita.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IPageService pageService;
        private readonly IUserClaimService userClaimService;

        public CategoryController(ICategoryService categoryService, IUserClaimService userClaimService, IPageService pageService)
        {
            this.pageService = pageService;
            this.categoryService = categoryService;
            this.userClaimService = userClaimService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await this.categoryService.GetCategoriesAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var category = await this.categoryService.GetCategoryAsync(id);
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var pages = await this.pageService.GetPagesAsync();
            var selectListItems = pages.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            });

            ViewBag.Pages = new SelectList(selectListItems, "Value", "Text");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pages = await this.pageService.GetPagesAsync();
            var selectListItems = pages.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            });

            ViewBag.Pages = new SelectList(selectListItems, "Value", "Text");
            var category = await this.categoryService.GetCategoryAsync(id);

            return View(new EditCategoryRequest
            {
                BackgroundImageUrl = category.BackgroundImage,
                CreatedBy = category.CreatedBy,
                Id = category.Id,
                SortOrder = category.SortOrder,
                LanguageId = category.LanguageId,
                MainImageUrl = category.MainImage,
                Name = category.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCategoryRequest category)
        {
            category.CreatedBy = this.userClaimService.GetUserName();
            if (ModelState.IsValid)
            {
                if (category.MainImage != null)
                {
                    category.MainImageUrl = await this.categoryService.SaveImageAsync(category.MainImage.OpenReadStream(), category.MainImage.FileName);
                }
                if (category.BackgroundImage != null)
                {
                    category.BackgroundImageUrl = await this.categoryService.SaveImageAsync(category.BackgroundImage.OpenReadStream(), category.BackgroundImage.FileName);
                }
                await this.categoryService.AddCategoryAsync(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCategoryRequest category)
        {
            if (ModelState.IsValid)
            {
                if (category.MainImage != null)
                {
                    category.MainImageUrl = await this.categoryService.SaveImageAsync(category.MainImage.OpenReadStream(), category.MainImage.FileName);
                }

                if (category.BackgroundImage != null)
                {
                    category.BackgroundImageUrl = await this.categoryService.SaveImageAsync(category.BackgroundImage.OpenReadStream(), category.BackgroundImage.FileName);
                }

                await this.categoryService.UpdateCategoryAsync(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }
    }
}
