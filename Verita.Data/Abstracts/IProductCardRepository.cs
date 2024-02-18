using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IProductCardRepository
    {
        Task AddProductCardAsync(ProductCard productCard);
        Task EditProductCardAsync(ProductCard productCard);
    }
}
