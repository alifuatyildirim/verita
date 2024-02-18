using Verita.Contract.Request.Product;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public interface IProductCardService
    {
        Task<ProductCard> AddProductCardAsync(AddProductCardRequest product);

        Task EditProductCardAsync(EditProductCardRequest productCard);
    }
}
