using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task EditProductAsync(Product product);
        Task<List<Product>> GetProductsAsync();
        Task<Product?> GetProductAsync(int id);
        Task<List<Product>> GetProductByCategoryIdAsync(int categoryId);
    }
}
