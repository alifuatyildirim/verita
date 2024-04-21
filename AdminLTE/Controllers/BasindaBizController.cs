using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Verita.Application;
using Verita.Application.BasindaBizService;
using Verita.Application.ProductService;
using Verita.Contract.Request.BasindaBiz;
using Verita.Contract.Request.Category;

namespace AdminLTE.Controllers
{
    [Authorize]
    public class BasindaBizController : Controller
    {
        private readonly IUserClaimService userClaimService;
        private readonly IBasindaBizService basindaBizService;
        public BasindaBizController(IBasindaBizService basindaBizService, IUserClaimService userClaimService)
        {
            this.userClaimService = userClaimService;
            this.basindaBizService = basindaBizService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var basindaBizList = await this.basindaBizService.GetBasindaBizListAsync();
            return View(basindaBizList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var category = await this.basindaBizService.GetBasindaBizAsync(id);
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
            var basindaBiz = await this.basindaBizService.GetBasindaBizAsync(id);

            return View(new EditBasindaBizRequest
            { 
                CreatedBy = basindaBiz.CreatedBy,
                Id = basindaBiz.Id,
                DateOfPublication = basindaBiz.DateOfPublication,
                SortOrder = basindaBiz.SortOrder,
                LanguageId = basindaBiz.LanguageId,
                ImageUrl = basindaBiz.Image,
                Name = basindaBiz.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddBasindaBizRequest basindaBiz)
        {
            basindaBiz.CreatedBy = this.userClaimService.GetUserName();
            if (ModelState.IsValid)
            {
                if (basindaBiz.Image != null)
                {
                    basindaBiz.ImageUrl = await this.basindaBizService.SaveImageAsync(basindaBiz.Image.OpenReadStream(), basindaBiz.Image.FileName);
                }
                await this.basindaBizService.AddCBasindaBizAsync(basindaBiz);
                return RedirectToAction("Index");
            }
            return View(basindaBiz);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBasindaBizRequest basindaBiz)
        {
            if (ModelState.IsValid)
            {
                if (basindaBiz.Image != null)
                {             
                    basindaBiz.ImageUrl = await this.basindaBizService.SaveImageAsync(basindaBiz.Image.OpenReadStream(), basindaBiz.Image.FileName);
                } 

                await this.basindaBizService.UpdateBasindaBizAsync(basindaBiz);
                return RedirectToAction("Index");
            }
            return View(basindaBiz);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.basindaBizService.DeleteBasindaBizAsync(id);
            return RedirectToAction("Index");
        }

    }
}
