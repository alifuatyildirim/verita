using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Verita.Common;
using Verita.Contract.Request.Product;
using Verita.Data.Abstracts;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public class ProductCardService : IProductCardService
    { 
        private readonly IProductCardRepository productCardRepository;
        public ProductCardService(IProductCardRepository productCardRepository)
        { 
            this.productCardRepository = productCardRepository;
        }

        public async Task<ProductCard> AddProductCardAsync(AddProductCardRequest request)
        {
            var productEntity = new ProductCard
            {
                
                Description = request.Description,
                Title = request.Title, 
                ProductId = request.ProductId,
                Image = request.ImageUrl,
            };
            await this.productCardRepository.AddProductCardAsync(productEntity);
            return productEntity;
        }

        public async Task EditProductCardAsync(EditProductCardRequest productCard)
        {
            var productEntity = new ProductCard
            {
                Id = productCard.Id!.Value,
                Description = productCard.Description,
                Title = productCard.Title,
                ProductId = productCard.ProductId,
                Image = productCard.ImageUrl,
            };
            await this.productCardRepository.EditProductCardAsync(productEntity); 
        }
    }
}
