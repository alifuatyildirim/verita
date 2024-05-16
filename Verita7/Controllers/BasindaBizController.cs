using Microsoft.AspNetCore.Mvc;
using Verita.Application.BasindaBizService;
using Verita.Application.ProductService;
using Verita.Common.Enums;

namespace Verita7.Controllers
{
    public class BasindaBizController : Controller
    {
        private readonly IBasindaBizService basindaBizService;  

        public BasindaBizController(IBasindaBizService basindaBizService)
        {
            this.basindaBizService = basindaBizService; 

        }
        public async Task<IActionResult> Index(int productId)
        {
            var basindaBiz = await this.basindaBizService.GetBasindaBizListAsync();
            for (int i = 0; i < 100; i++)
            {
                int a = new Random().Next(0,3);
                basindaBiz.Add(new Verita.Domain.Entities.BasindaBiz
                {
                    ContentType = Verita.Common.Enums.BasindaBizContentType.Image,
                    Image = basindaBiz[0].Image,
                    Id = i + 100,
                    DateOfPublication = DateTime.Now,
                    Name = "test" + i,
                    LabelType = (LabelType)a,
                    Link = "LİNK",
                    Resource = "RESOURCE",
                    SortOrder = 1,
                    LanguageId = Language.Tr,

                });
            }
            return View(basindaBiz);
        }
    }
}
