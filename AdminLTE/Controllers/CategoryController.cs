using Microsoft.AspNetCore.Mvc;
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
        private readonly IUserClaimService userClaimService;

        public CategoryController(ICategoryService categoryService, IUserClaimService userClaimService)
        {
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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await this.categoryService.GetCategoryAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCategoryRequest category)
        {
            category.CreatedBy = this.userClaimService.GetUserName();
            if (ModelState.IsValid)
            {
                await this.categoryService.AddCategoryAsync(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
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
