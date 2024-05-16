using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Verita.Application;
using Verita.Application.MeyveliRehberService;
using Verita.Application.ProductService;
using Verita.Contract.Request.MeyveliRehber;
using Verita.Contract.Request.Category;

namespace AdminLTE.Controllers
{
    [Authorize]
    public class MeyveliRehberController : Controller
    {
        private readonly IUserClaimService userClaimService;
        private readonly IMeyveliRehberService MeyveliRehberService;
        public MeyveliRehberController(IMeyveliRehberService MeyveliRehberService, IUserClaimService userClaimService)
        {
            this.userClaimService = userClaimService;
            this.MeyveliRehberService = MeyveliRehberService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var MeyveliRehberList = await this.MeyveliRehberService.GetMeyveliRehberListAsync();
            return View(MeyveliRehberList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var category = await this.MeyveliRehberService.GetMeyveliRehberAsync(id);
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
            var MeyveliRehber = await this.MeyveliRehberService.GetMeyveliRehberAsync(id);

            return View(new EditMeyveliRehberRequest
            { 
                CreatedBy = MeyveliRehber.CreatedBy,
                Id = MeyveliRehber.Id,
                DateOfPublication = MeyveliRehber.DateOfPublication,
                SortOrder = MeyveliRehber.SortOrder,
                LanguageId = MeyveliRehber.LanguageId,
                ImageUrl = MeyveliRehber.Image,
                Name = MeyveliRehber.Name,
                Link = MeyveliRehber.Link,
                MeyveliRehberType = MeyveliRehber.MeyveliRehberType,
                FileUrl = MeyveliRehber.File
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddMeyveliRehberRequest MeyveliRehber)
        {
            MeyveliRehber.CreatedBy = this.userClaimService.GetUserName();
            if (ModelState.IsValid)
            {
                if (MeyveliRehber.Image != null)
                {
                    MeyveliRehber.ImageUrl = await this.MeyveliRehberService.SaveImageAsync(MeyveliRehber.Image.OpenReadStream(), MeyveliRehber.Image.FileName);
                }
                await this.MeyveliRehberService.AddMeyveliRehberAsync(MeyveliRehber);
                return RedirectToAction("Index");
            }
            return View(MeyveliRehber);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditMeyveliRehberRequest MeyveliRehber)
        {
            if (ModelState.IsValid)
            {
                if (MeyveliRehber.Image != null)
                {             
                    MeyveliRehber.ImageUrl = await this.MeyveliRehberService.SaveImageAsync(MeyveliRehber.Image.OpenReadStream(), MeyveliRehber.Image.FileName);
                } 

                await this.MeyveliRehberService.UpdateMeyveliRehberAsync(MeyveliRehber);
                return RedirectToAction("Index");
            }
            return View(MeyveliRehber);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.MeyveliRehberService.DeleteMeyveliRehberAsync(id);
            return RedirectToAction("Index");
        }

    }
}
