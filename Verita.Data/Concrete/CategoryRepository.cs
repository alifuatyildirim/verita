﻿using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IGenericRepository genericRepository;
        public CategoryRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await this.genericRepository.AddAsync(category);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await this.genericRepository.GetListAsync<Category>();
        }
        public async Task<Category> GetCategoryAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<Category>(id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            this.genericRepository.Update<Category>(category);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await this.GetCategoryAsync(categoryId);
            await this.genericRepository.DeleteAsync<Category>(category);
            await this.genericRepository.SaveChangesAsync();
        }
    }
}