using Verita.Contract.Request.Product;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public interface IProductOrderItemService
    {
        Task<ProductOrderItem> AddProductOrderItemAsync(AddProductOrderItemRequest product);

        Task EditProductOrderItemAsync(EditProductOrderItemRequest productCard);
    }
}
