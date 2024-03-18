using Verita.Application.Image;
using Verita.Contract.Request.Product;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public interface IProductService : IImageService
    {
        Task<Product> AddProductAsync(AddProductRequest product);
        Task<List<Product>> GetProductByCategoryIdAsync(int categoryId);
        Task EditProductAsync(EditProductRequest product);
        Task<List<Product>> GetProductsAsync(); 
        Task<Product?> GetProductAsync(int id);
    }
}
