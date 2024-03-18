using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IProductOrderItemRepository
    {
        Task AddProductOrderItemAsync(ProductOrderItem productOrderItem);
        Task EditProductOrderItemAsync(ProductOrderItem productOrderItem);
    }
}
