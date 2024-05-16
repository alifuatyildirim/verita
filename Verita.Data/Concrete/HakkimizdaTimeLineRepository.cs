using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class HakkimizdaTimeLineRepository : IHakkimizdaTimeLineRepository
    {
        private readonly IGenericRepository genericRepository;
        public HakkimizdaTimeLineRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddHakkimizdaTimeLineAsync(HakkimizdaTimeLine content)
        {
            await this.genericRepository.AddAsync(content);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<List<HakkimizdaTimeLine>> GetHakkimizdaTimeLineListAsync()
        {
            return await this.genericRepository.GetListAsync<HakkimizdaTimeLine>();
        }
        public async Task<HakkimizdaTimeLine> GetHakkimizdaTimeLineAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<HakkimizdaTimeLine>(id);
        }

        public async Task UpdateHakkimizdaTimeLineAsync(HakkimizdaTimeLine content)
        {
            var contentEntity = await this.GetHakkimizdaTimeLineAsync(content.Id);
            if (contentEntity is null)
            {
                return;
            }
            contentEntity.IsActive = content.IsActive;
            contentEntity.Year = content.Year;
            contentEntity.SortOrder = content.SortOrder; 
            contentEntity.Description = content.Description;

            this.genericRepository.Update(contentEntity);
           await this.genericRepository.SaveChangesAsync();
        }

        public async Task DeleteHakkimizdaTimeLineAsync(int contentId)
        {
            var content = await this.GetHakkimizdaTimeLineAsync(contentId);
            await this.genericRepository.DeleteAsync<HakkimizdaTimeLine>(content);
            await this.genericRepository.SaveChangesAsync();
        } 
    }
}
