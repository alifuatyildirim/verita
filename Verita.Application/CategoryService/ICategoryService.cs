using Verita.Application.Image;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.Product;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public interface ICategoryService :IImageService
    {
        Task AddCategoryAsync(AddCategoryRequest category);
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task UpdateCategoryAsync(EditCategoryRequest category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
