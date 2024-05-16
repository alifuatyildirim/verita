using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Verita.Application;
using Verita.Application.HakkimizdaService;
using Verita.Application.HomePageSliderService;
using Verita.Contract.Request.Hakkimizda;
using Verita.Domain.Entities;

namespace AdminLTE.Controllers
{
    [Authorize]
    public class HakkimizdaController : Controller
    {
        private readonly IHakkimizdaService HakkimizdaService;
        private readonly IUserClaimService userClaimService;
        public HakkimizdaController(IHakkimizdaService HakkimizdaService, IUserClaimService userClaimService)
        {
            this.HakkimizdaService = HakkimizdaService;
            this.userClaimService = userClaimService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
 
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
            var Hakkimizda = await this.HakkimizdaService.GetHakkimizdaAsync(id);
            return View(Hakkimizda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddHakkimizdaRequest Hakkimizda)
        {
            if (ModelState.IsValid)
            {
                if (Hakkimizda.Image1 != null)
                {
                    Hakkimizda.ImageUrl1= await this.HakkimizdaService.SaveImageAsync(Hakkimizda.Image1.OpenReadStream(), Hakkimizda.Image1.FileName);
                }
                if (Hakkimizda.Image2 != null)
                {
                    Hakkimizda.ImageUrl2 = await this.HakkimizdaService.SaveImageAsync(Hakkimizda.Image2.OpenReadStream(), Hakkimizda.Image2.FileName);
                }

                if (Hakkimizda.BackgroundImage != null)
                {
                    Hakkimizda.BackgroundImageUrl = await this.HakkimizdaService.SaveImageAsync(Hakkimizda.BackgroundImage.OpenReadStream(), Hakkimizda.BackgroundImage.FileName);
                }

                await this.HakkimizdaService.AddHakkimizdaAsync(Hakkimizda); 
                

                return RedirectToAction("Index", "Hakkimizda");
            }
             
            return View(Hakkimizda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditHakkimizdaRequest Hakkimizda)
        {
            if (ModelState.IsValid)
            {
                if (Hakkimizda.Image1 != null)
                {
                    Hakkimizda.ImageUrl1 = await this.HakkimizdaService.SaveImageAsync(Hakkimizda.Image1.OpenReadStream(), Hakkimizda.Image1.FileName);
                }
                if (Hakkimizda.Image2 != null)
                {
                    Hakkimizda.ImageUrl2 = await this.HakkimizdaService.SaveImageAsync(Hakkimizda.Image2.OpenReadStream(), Hakkimizda.Image2.FileName);
                }

                if (Hakkimizda.BackgroundImage != null)
                {
                    Hakkimizda.BackgroundImageUrl = await this.HakkimizdaService.SaveImageAsync(Hakkimizda.BackgroundImage.OpenReadStream(), Hakkimizda.BackgroundImage.FileName);
                }

                await this.HakkimizdaService.UpdateHakkimizdaAsync(Hakkimizda);

                

                return RedirectToAction("Index", "Hakkimizda");
            }

            return View(Hakkimizda);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Hakkimizdas = await HakkimizdaService.GetHakkimizdaListAsync();
            return View(Hakkimizdas);
        }
    }
}
