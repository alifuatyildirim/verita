using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
    }
}
