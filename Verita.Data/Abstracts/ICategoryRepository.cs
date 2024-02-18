using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(Category category);
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
