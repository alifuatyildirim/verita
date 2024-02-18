using Verita.Contract.Request.Category;
using Verita.Data.Abstracts;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task AddCategoryAsync(AddCategoryRequest category)
        {
            await this.categoryRepository.AddCategoryAsync(new Category
            {
                CreatedBy = category.CreatedBy,
                LanguageId = category.LanguageId,
                SortOrder = category.SortOrder,
                Name = category.Title,
            });
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await this.categoryRepository.DeleteCategoryAsync(categoryId);
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var list = await this.categoryRepository.GetCategoriesAsync();
            return list.OrderBy(x => x.SortOrder).ToList();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await this.categoryRepository.GetCategoryAsync(id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            category.UpdatedDate = DateTime.Now;
            await this.categoryRepository.UpdateCategoryAsync(category);
        }
    }
}
