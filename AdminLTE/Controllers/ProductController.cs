using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Verita.Application;
using Verita.Application.ProductService;
using Verita.Contract.Request.Product;

namespace AdminLTE.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IUserClaimService userClaimService;
        public ProductController(IProductService productService, IUserClaimService userClaimService)
        {
            this.productService = productService;
            this.userClaimService = userClaimService;
        }

        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductRequest request)
        {
            request.CreatedBy = this.userClaimService.GetUserName();
            await productService.AddProductAsync(request);
            return View();
        }
    }
}
