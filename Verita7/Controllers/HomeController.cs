using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verita.Application.ProductService;

namespace Verita7.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;

        }

        public async Task<IActionResult> CategoriesPartialView()
        {
            ViewBag.CategoriesTitle = await this.categoryService.GetCategoriesAsync();
            ViewBag.ProductsTitle = await this.productService.GetProductsAsync();
            return PartialView("~/Views/Shared/CategoriesPartialView.cshtml");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Urunlerimiz()
        {
            return View();
        }

        public ActionResult GidaGuvenligi()
        {
            return View();
        }
        public ActionResult MerakEttikleriniz()
        {
            return View();
        }

        public ActionResult Verita()
        {
            return View();
        }
        public ActionResult B2bUrunler()
        {
            return View();
        }

        public ActionResult B2bUrun()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }

        public ActionResult BasindaBiz()
        {
            return View();
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult EgzotikMeyveler()
        {
            return View();
        }

        public ActionResult VeritaGurmeKivi()
        {
            return View();
        }

        public ActionResult VeritaGurmeKivi2()
        {
            return View();
        }
        public ActionResult BunlariBiliyorMusunuz()
        {
            return View();
        }

        public ActionResult OrganizasyonYapisi()
        {
            return View();
        }

        public ActionResult OrganizasyonYapisi2()
        {
            return View();
        }

        public ActionResult Hedeflerimiz()
        {
            return View();
        }
        public ActionResult NedenVerita()
        {
            return View();
        }

        public ActionResult KaliteGarantisi()
        {
            return View();
        }
    }
}
