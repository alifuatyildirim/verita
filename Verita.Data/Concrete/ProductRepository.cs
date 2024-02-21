using Microsoft.EntityFrameworkCore;
using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IGenericRepository genericRepository;
        public ProductRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddProductAsync(Product product)
        {
                await this.genericRepository.AddAsync(product);
                await this.genericRepository.SaveChangesAsync();    
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await this.genericRepository.GetQueryable<Product>().Include(x=>x.Category).ToListAsync();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await this.genericRepository.GetQueryable<Product>().Include(x => x.Category).Include(x=>x.ProductCards).FirstOrDefaultAsync(x=>x.Id == id);
           
        }

        public async Task EditProductAsync(Product product)
        {
            var productEntity = await this.GetProductAsync(product.Id);
            if (productEntity is null)
            {
                return;
            }

            if (!string.IsNullOrEmpty( product.MainImageUrl)) 
            {
                productEntity.MainImageUrl = product.MainImageUrl;
            }
            productEntity.Name = product.Name;
            productEntity.LanguageId = product.LanguageId;
            productEntity.Description = product.Description;
            productEntity.Title = product.Title;
            productEntity.CategoryId = product.CategoryId;
            productEntity.UpdatedBy = product.UpdatedBy;
            productEntity.UpdatedDate = product.UpdatedDate;

            this.genericRepository.Update(productEntity);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductByCategoryIdAsync(int categoryId)
        {
            return await this.genericRepository.GetQueryable<Product>().Include(x => x.Category).Where(x => x.CategoryId == categoryId).ToListAsync();
        }
    }
}
