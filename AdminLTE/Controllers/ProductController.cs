using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Verita.Application;
using Verita.Application.ProductService;
using Verita.Contract.Request.Product;
using Verita.Domain.Entities;

namespace AdminLTE.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IProductCardService productCardService;
        private readonly IProductOrderItemService productOrderItemService;
        private readonly ICategoryService categoryService;
        private readonly IUserClaimService userClaimService;
        public ProductController(IProductService productService, IProductOrderItemService productOrderItemService,IUserClaimService userClaimService, ICategoryService categoryService, IProductCardService productCardService)
        {
            this.productService = productService;
            this.userClaimService = userClaimService;
            this.categoryService = categoryService;
            this.productCardService = productCardService; 
            this.productOrderItemService = productOrderItemService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await categoryService.GetCategoriesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
            ViewBag.Categories = await categoryService.GetCategoriesAsync();
            var product = await this.productService.GetProductAsync(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddProductRequest product)
        {
            product.CreatedBy = userClaimService.GetUserName();
            if (ModelState.IsValid)
            {
                if (product.MainImage != null)
                {
                    product.MainImageUrl = await this.productService.SaveImageAsync(product.MainImage.OpenReadStream(), product.MainImage.FileName);
                }

                if (product.BackgroundImage != null)
                {
                    product.BackgroundImageUrl = await this.productService.SaveImageAsync(product.BackgroundImage.OpenReadStream(), product.BackgroundImage.FileName);
                }

                var productEntity =  await this.productService.AddProductAsync(product);

                // Ürün kartları da kaydedilmeli
                if (product.ProductCards != null && product.ProductCards.Any())
                {
                    foreach (var card in product.ProductCards)
                    {
                        await this.productCardService.AddProductCardAsync(new AddProductCardRequest
                        {
                            CreatedBy = product.CreatedBy,
                            ProductId = productEntity.Id,
                            Title = card.Title,
                            Description = card.Description,
                            ImageUrl = await this.productService.SaveImageAsync(card.Image.OpenReadStream(), card.Image.FileName),
                    });
                    }
                }

                if (product.ProductOrderItems!= null && product.ProductOrderItems.Any())
                {
                    foreach (var card in product.ProductOrderItems)
                    {
                        await this.productOrderItemService.AddProductOrderItemAsync(new AddProductOrderItemRequest
                        {
                            CreatedBy = product.CreatedBy,
                            ProductId = productEntity.Id,
                            Title = card.Title,
                            Url = card.Url,
                            ImageUrl = await this.productService.SaveImageAsync(card.Image.OpenReadStream(), card.Image.FileName)
                        });
                    }
                }

                return RedirectToAction("Index", "Product");
            }

            ViewBag.Categories = await this.categoryService.GetCategoriesAsync();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProductRequest product)
        {
            product.CreatedBy = userClaimService.GetUserName();
            if (ModelState.IsValid)
            {
                if (product.MainImage != null)
                {
                    product.MainImageUrl = await this.productService.SaveImageAsync(product.MainImage.OpenReadStream(), product.MainImage.FileName);
                }

                if (product.BackgroundImage != null)
                {
                    product.BackgroundImageUrl = await this.productService.SaveImageAsync(product.BackgroundImage.OpenReadStream(), product.BackgroundImage.FileName);
                }

                await this.productService.EditProductAsync(product);

                // Ürün kartları da kaydedilmeli
                if (product.ProductCards != null && product.ProductCards.Any())
                {
                    foreach (var card in product.ProductCards)
                    {
                        string imageUrl = string.Empty;
                        if (card.Image != null)
                        {
                            imageUrl = await this.productService.SaveImageAsync(card.Image.OpenReadStream(), card.Image.FileName);
                        }
                        if (card.Id == null) 
                        {
                            await this.productCardService.AddProductCardAsync(new AddProductCardRequest
                            {
                                CreatedBy = product.CreatedBy,
                                ProductId = product.Id,
                                Title = card.Title,
                                Description = card.Description,
                                ImageUrl = await this.productService.SaveImageAsync(card.Image.OpenReadStream(), card.Image.FileName)
                            });
                            continue;
                        }
                        await this.productCardService.EditProductCardAsync(new EditProductCardRequest
                        {
                            Id= card.Id,
                            CreatedBy = product.CreatedBy,
                            ProductId = product.Id,
                            Title = card.Title,
                            Description = card.Description,
                            ImageUrl = imageUrl
                        });
                    }
                }



                if (product.ProductOrderItems!= null && product.ProductOrderItems.Any())
                {
                    foreach (var orderItem in product.ProductOrderItems)
                    {
                        string imageUrl = string.Empty;
                        if (orderItem.Image != null)
                        {
                            imageUrl = await this.productService.SaveImageAsync(orderItem.Image.OpenReadStream(), orderItem.Image.FileName);
                        }
                        if (orderItem.Id == null)
                        {
                            await this.productOrderItemService.AddProductOrderItemAsync(new AddProductOrderItemRequest
                            {
                                CreatedBy = product.CreatedBy,
                                ProductId = product.Id,
                                Title = orderItem.Title,
                                Url = orderItem.Url,
                                ImageUrl = await this.productService.SaveImageAsync(orderItem.Image.OpenReadStream(), orderItem.Image.FileName)
                            });
                            continue;
                        }
                        await this.productOrderItemService.EditProductOrderItemAsync(new EditProductOrderItemRequest
                        {
                            Id = orderItem.Id,
                            CreatedBy = product.CreatedBy,
                            ProductId = product.Id,
                            Title = orderItem.Title,
                            Url = orderItem.Url,
                            ImageUrl = imageUrl
                        });
                    }
                }

                return RedirectToAction("Index", "Product");
            }

            ViewBag.Categories = await this.categoryService.GetCategoriesAsync();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProductsAsync();
            return View(products);
        }
    }
}
