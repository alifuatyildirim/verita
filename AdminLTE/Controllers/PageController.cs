using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verita.Application;
using Verita.Application.ProductService;
using Verita.Contract.Request.Product;
using Verita.Domain.Entities;

namespace AdminLTE.Controllers
{
    [Authorize]
    public class PageController : Controller
    {
        private readonly IPageService pageService;
        private readonly IPageImageService pageImageService;
        private readonly IUserClaimService userClaimService;
        public PageController(IPageService pageService, IUserClaimService userClaimService, IPageImageService pageImageService)
        {
            this.pageService = pageService;
            this.userClaimService = userClaimService;
            this.pageImageService = pageImageService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var page = await this.pageService.GetPageAsync(id);
            return View(page);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddPageRequest page)
        {
            page.CreatedBy = userClaimService.GetUserName();
            if (ModelState.IsValid)
            {
                if (page.BackgroundImage != null)
                {
                    page.BackgroundUrl = await this.pageService.SaveImageAsync(page.BackgroundImage.OpenReadStream(), page.BackgroundImage.FileName);
                }

                var productEntity = await this.pageService.AddPageAsync(page);

                if (page.PageImages != null && page.PageImages.Any())
                {
                    foreach (var image in page.PageImages)
                    {
                        await this.pageImageService.AddPageImageAsync(new AddPageImageRequest
                        {
                            CreatedBy = page.CreatedBy,
                            PageId = productEntity.Id,
                            Title = image.Title,
                            Description = image.Description,
                            ImageUrl = await this.pageService.SaveImageAsync(image.Image.OpenReadStream(), image.Image.FileName)
                        });
                    }
                }

                return RedirectToAction("Index", "Page");
            }

            return View(page);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditPageRequest page)
        {
            if (ModelState.IsValid)
            {
                if (page.BackgroundImage != null)
                {
                    page.BackgroundUrl = await this.pageService.SaveImageAsync(page.BackgroundImage.OpenReadStream(), page.BackgroundImage.FileName);
                }

                await this.pageService.EditPageAsync(page);

                if (page.PageImages != null && page.PageImages.Any())
                {
                    foreach (var image in page.PageImages)
                    {
                        string imageUrl = string.Empty;
                        if (image.Image != null)
                        {
                            imageUrl = await this.pageService.SaveImageAsync(image.Image.OpenReadStream(), image.Image.FileName);
                        }
                        if (image.Id == null)
                        {
                            await this.pageImageService.AddPageImageAsync(new AddPageImageRequest
                            {
                                CreatedBy = page.CreatedBy,
                                PageId = page.Id,
                                Title = image.Title,
                                Description = image.Description,
                                ImageUrl = await this.pageService.SaveImageAsync(image.Image.OpenReadStream(), image.Image.FileName)
                            });
                            continue;
                        }
                        await this.pageImageService.EditPageImageAsync(new EditPageImageRequest
                        {
                            Id = image.Id,
                            CreatedBy = page.CreatedBy,
                            PageId = page.Id,
                            Title = image.Title,
                            Description = image.Description,
                            ImageUrl = imageUrl
                        });
                    }
                }

                return RedirectToAction("Index", "Page");
            }

            return View(page);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await pageService.GetPagesAsync();
            return View(products);
        }
    }
}
