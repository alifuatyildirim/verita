using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Verita.Application.HomePageSliderService;
using Verita.Application.NedenVeritaService;
using Verita.Application.ProductService;
using Verita.Common.Enums;
using Verita.Domain.Entities;

namespace Verita7.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly IPageService pageService;
        private readonly ICategoryService categoryService;
        private readonly IHomePageContentService homePageContentService;
        private readonly IHomePageSliderService homePageSliderService;
        private readonly INedenVeritaService nedenVeritaService;
        private readonly IReferanslarService referanslarService;

        public HomeController(IProductService productService, ICategoryService categoryService, IPageService pageService, IHomePageContentService homePageContentService, IHomePageSliderService homePageSliderService, INedenVeritaService nedenVeritaService, IReferanslarService referanslarService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.pageService = pageService;
            this.homePageContentService = homePageContentService;
            this.homePageSliderService = homePageSliderService;
            this.nedenVeritaService = nedenVeritaService;
            this.referanslarService = referanslarService;

        }

        public async Task<IActionResult> CategoriesPartialView()
        {

            ViewBag.CategoriesTitle = await this.categoryService.GetCategoriesAsync();
            ViewBag.ProductsTitle = await this.productService.GetProductsAsync();
            return PartialView("~/Views/Shared/CategoriesPartialView.cshtml");
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.Sliders = await this.homePageSliderService.GetHomePageSliderListAsync();
            var content = await this.homePageContentService.GetHomePageContentListAsync();
            ViewBag.GuvenliGida = content.FirstOrDefault(x => x.ContentType == HomePageContentType.GuvenliGida);
            ViewBag.Hakkimizda = content.FirstOrDefault(x => x.ContentType == HomePageContentType.Hakkimizda);
            ViewBag.NedenVeritaContent = content.FirstOrDefault(x => x.ContentType == HomePageContentType.NedenVerita);
            ViewBag.NedenVerita = await this.nedenVeritaService.GetNedenVeritaListAsync();
             
            ViewBag.Referanslar = await this.referanslarService.GetReferanslarListAsync();
            var pages = await this.pageService.GetPagesAsync();
            ViewBag.DalindanSofraya = pages.Where(x => x.Name.StartsWith("Dalından")).FirstOrDefault()?.Id;
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
        public async Task<IActionResult> BunlariBiliyorMusunuz()
        {
            ViewBag.PageCategories = await this.pageService.GetPagesByCategoryAsync(PageCategory.MerakEttikleriniz);
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

        public ActionResult DalindanSofraya()
        {
            return View();
        }

        public ActionResult GuvenliAmbalaj()
        {
            return View();
        }

        public ActionResult SogukZincir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BizeUlasin(string FullName, string Email, string Subject, string Enquiry)
        {

            string fromAddress = "bilisimuzamni2017@gmail.com"; // gönderici mail
            string toAddress = "alifuat.yildirim@hotmail.com"; //alıcı mail
            const string fromPassword = "Aa13582."; // Uygulama şifresi

            // E-posta göndermek için SmtpClient oluşturun ve Gmail SMTP sunucusunu belirtin
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true, 
                Credentials = new NetworkCredential(fromAddress, fromPassword)
            };

            // E-posta oluşturun ve gönderilecek kişi, konu ve içeriği belirtin
            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = Subject,
                Body = "Ad Soyad: " + FullName + "\nE-Posta: " + Email + "\nMesaj: " + Enquiry
            };

            try
            {
                // E-postayı gönder
                smtp.Send(message);
                Console.WriteLine("E-posta başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderilirken hata oluştu: " + ex.Message);
            }
            return RedirectToAction("Iletisim");
        }
    }
}
