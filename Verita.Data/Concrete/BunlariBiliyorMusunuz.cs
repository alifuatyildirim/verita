using Microsoft.EntityFrameworkCore;
using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class BunlariBiliyorMusunuzRepository : IBunlariBiliyorMusunuzRepository
    {
        private readonly IGenericRepository genericRepository;
        public BunlariBiliyorMusunuzRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddBunlariBiliyorMusunuzAsync(BunlariBiliyorMusunuz content)
        {
            await this.genericRepository.AddAsync(content);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<List<BunlariBiliyorMusunuz>> GetBunlariBiliyorMusunuzListAsync()
        {
            return await this.genericRepository.GetListAsync<BunlariBiliyorMusunuz>();
        }
        public async Task<BunlariBiliyorMusunuz> GetBunlariBiliyorMusunuzAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<BunlariBiliyorMusunuz>(id);
        }

        public async Task UpdateBunlariBiliyorMusunuzAsync(BunlariBiliyorMusunuz content)
        {
            var contentEntity = await this.GetBunlariBiliyorMusunuzAsync(content.Id);
            if (contentEntity is null)
            {
                return;
            }
            contentEntity.IsActive = content.IsActive;
            contentEntity.SortOrder = content.SortOrder;
            contentEntity.Title = content.Title;   
            contentEntity.Description = content.Description;

            this.genericRepository.Update(contentEntity);
           await this.genericRepository.SaveChangesAsync();
        }

        public async Task DeleteBunlariBiliyorMusunuzAsync(int contentId)
        {
            var content = await this.GetBunlariBiliyorMusunuzAsync(contentId);
            await this.genericRepository.DeleteAsync<BunlariBiliyorMusunuz>(content);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<BunlariBiliyorMusunuz?> FindBunlariBiliyorMusunuzAsync(string text)
        {
            return await this.genericRepository.GetQueryable<BunlariBiliyorMusunuz>().FirstOrDefaultAsync(x => x.Description.Contains(text));
        }
    }
}
