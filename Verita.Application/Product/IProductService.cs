using Verita.Contract.Request.Product;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(AddProductRequest product);
        Task<List<Product>> GetProductByCategoryIdAsync(int categoryId);
        Task EditProductAsync(EditProductRequest product);
        Task<string> SaveImageAsync(Stream imageStream, string fileName);
        Task<List<Product>> GetProductsAsync(); 
        Task<Product?> GetProductAsync(int id);
    }
}
