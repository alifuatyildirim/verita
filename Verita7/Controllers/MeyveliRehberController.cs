    using Microsoft.AspNetCore.Mvc;
using Verita.Application.BasindaBizService;
using Verita.Application.BunlariBiliyorMusunuzService;
using Verita.Application.MeyveliRehberService;
using Verita.Application.ProductService;
using Verita.Common.Enums;

namespace Verita7.Controllers
{
    public class MeyveliRehberController : Controller
    {

        private readonly IMeyveliRehberService meyveliRehberService;  

        public MeyveliRehberController(IMeyveliRehberService meyveliRehberService)
        {
            this.meyveliRehberService = meyveliRehberService; 
        }
        public async Task<IActionResult> Index()
        { 
            var meyveliRehber = await this.meyveliRehberService.GetMeyveliRehberListAsync();
           
            return View(meyveliRehber);
        }
    }
}
