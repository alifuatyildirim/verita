using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Verita.Common;
using Verita.Contract.Request.Product;
using Verita.Data.Abstracts;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task AddProductAsync(AddProductRequest request)
        {
            await this.productRepository.AddProductAsync(new Product
            {
                Title = request.Title,
                Description = request.Description,
                CreatedBy = request.CreatedBy
            });
        }
    }
}
