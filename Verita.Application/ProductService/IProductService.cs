using Verita.Contract.Request.Product;

namespace Verita.Application.ProductService
{
    public interface IProductService
    {
        Task AddProductAsync(AddProductRequest request);
    }
}
