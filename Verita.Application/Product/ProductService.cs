using Verita.Application.Image;
using Verita.Contract.Request.Product;
using Verita.Data.Abstracts;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public class ProductService : ImageService,IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IProductCardRepository productCardRepository;
        public ProductService(IProductRepository productRepository, IProductCardRepository productCardRepository)
        {
            this.productRepository = productRepository;
            this.productCardRepository = productCardRepository;
        }

        public async Task<Product> AddProductAsync(AddProductRequest product)
        {
            var productEntity = new Product
            {
                BackgroundImageUrl = product.BackgroundImageUrl,
                CreatedBy = product.CreatedBy,
                CategoryId = product.CategoryId,
                LanguageId = product.LanguageId,
                Description = product.Description,
                Title = product.Title,
                Name = product.Name,
                MainImageUrl = product.MainImageUrl,
            };
            await this.productRepository.AddProductAsync(productEntity);
            return productEntity;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await this.productRepository.GetProductsAsync();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await this.productRepository.GetProductAsync(id);
        }

     

        public async Task EditProductAsync(EditProductRequest product)
        {
            var productEntity = new Product
            {
                Id = product.Id,
                CreatedBy = product.CreatedBy,
                CategoryId = product.CategoryId,
                LanguageId = product.LanguageId,
                Description = product.Description,
                Title = product.Title,
                Name = product.Name,
                MainImageUrl = product.MainImageUrl,
                BackgroundImageUrl = product.BackgroundImageUrl,
            };
            await this.productRepository.EditProductAsync(productEntity);
        }

        public async Task<List<Product>> GetProductByCategoryIdAsync(int categoryId)
        {
            return await this.productRepository.GetProductByCategoryIdAsync(categoryId);
        }
    }
}
