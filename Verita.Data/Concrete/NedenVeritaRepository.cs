using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class NedenVeritaRepository : INedenVeritaRepository
    {
        private readonly IGenericRepository genericRepository;
        public NedenVeritaRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddNedenVeritaAsync(NedenVerita content)
        {
            await this.genericRepository.AddAsync(content);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<List<NedenVerita>> GetNedenVeritaListAsync()
        {
            return await this.genericRepository.GetListAsync<NedenVerita>();
        }
        public async Task<NedenVerita> GetNedenVeritaAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<NedenVerita>(id);
        }

        public async Task UpdateNedenVeritaAsync(NedenVerita content)
        {
            var contentEntity = await this.GetNedenVeritaAsync(content.Id);
            if (contentEntity is null)
            {
                return;
            }
            contentEntity.Name = content.Name;
            contentEntity.City = content.City;
            contentEntity.SortOrder = content.SortOrder;
            contentEntity.Title = content.Title;   
            contentEntity.Description = content.Description;

            this.genericRepository.Update(contentEntity);
           await this.genericRepository.SaveChangesAsync();
        }

        public async Task DeleteNedenVeritaAsync(int contentId)
        {
            var content = await this.GetNedenVeritaAsync(contentId);
            await this.genericRepository.DeleteAsync<NedenVerita>(content);
            await this.genericRepository.SaveChangesAsync();
        } 
    }
}
