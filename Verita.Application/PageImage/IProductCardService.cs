using Verita.Contract.Request.Product;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public interface IPageImageService
    {
        Task<PageImage> AddPageImageAsync(AddPageImageRequest pageImage);

        Task EditPageImageAsync(EditPageImageRequest pageImage);
    }
}
