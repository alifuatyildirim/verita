using Microsoft.EntityFrameworkCore;
using Verita.Common.Enums;
using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class PageRepository : IPageRepository
    {
        private readonly IGenericRepository genericRepository;
        public PageRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddPageAsync(Page page)
        {
                await this.genericRepository.AddAsync(page);
                await this.genericRepository.SaveChangesAsync();    
        }

        public async Task<List<Page>> GetPagesAsync()
        {
            return await this.genericRepository.GetQueryable<Page>().ToListAsync();
        }

        public async Task<Page?> GetPageAsync(int id)
        {
            return await this.genericRepository.GetQueryable<Page>().Include(x=>x.PageImages).FirstOrDefaultAsync(x=>x.Id == id);
           
        }

        public async Task EditPageAsync(Page page)
        {
            var pageEntity = await this.GetPageAsync(page.Id);
            if (pageEntity is null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(page.BackgroundUrl)) 
            {
                pageEntity.BackgroundUrl = page.BackgroundUrl;
            }
            pageEntity.Name = page.Name;
            pageEntity.LanguageId = page.LanguageId;
            pageEntity.Description = page.Description;
            pageEntity.Title = page.Title; 
            pageEntity.UpdatedBy = page.UpdatedBy;
            pageEntity.UpdatedDate = page.UpdatedDate;
            pageEntity.PageCategory = page.PageCategory;

            this.genericRepository.Update(pageEntity);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<List<Page>> GetPagesByCategoryAsync(PageCategory pageCategory)
        {
            return await this.genericRepository.GetQueryable<Page>().Where(x=>x.PageCategory == pageCategory).ToListAsync();
        }
    }
}
