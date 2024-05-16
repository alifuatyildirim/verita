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
                    ContentType = Verita.Common.Enums.BasindaBizContentType.Link,
                    Image = basindaBiz[0].Image,
                    Id = i + 100,
                    DateOfPublication = DateTime.Now,
                    Name = "test" + i,
                    LabelType = (LabelType)a,
                    Link = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/4TK4LrYpJys?si=c_96OKGDfzIboLBf\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" referrerpolicy=\"strict-origin-when-cross-origin\" allowfullscreen></iframe>",
                    Resource = "RESOURCE",
                    SortOrder = 1,
                    LanguageId = Language.Tr,

                });
            }
            return View(basindaBiz);
        }
    }
}
