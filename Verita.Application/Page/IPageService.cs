using Verita.Contract.Request.Product;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public interface IPageService
    {
        Task<Page> AddPageAsync(AddPageRequest page); 
        Task EditPageAsync(EditPageRequest product);
        Task<string> SaveImageAsync(Stream imageStream, string fileName);
        Task<List<Page>> GetPagesAsync(); 
        Task<Page?> GetPageAsync(int id);
    }
}
