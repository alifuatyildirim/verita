using Verita.Data.Abstracts;
using Verita.Domain;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class ReferanslarRepository : IReferanslarRepository
    {
        private readonly IGenericRepository genericRepository;
        public ReferanslarRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddReferanslarAsync(Referanslar content)
        {
            await this.genericRepository.AddAsync(content);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<List<Referanslar>> GetReferanslarListAsync()
        {
            return await this.genericRepository.GetListAsync<Referanslar>();
        }
        public async Task<Referanslar> GetReferanslarAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<Referanslar>(id);
        }

        public async Task UpdateReferanslarAsync(Referanslar content)
        {
            var contentEntity = await this.GetReferanslarAsync(content.Id);
            if (contentEntity is null)
            {
                return;
            }
            if (!string.IsNullOrWhiteSpace(content.Image))
            {
                contentEntity.Image = content.Image;
            }

            contentEntity.SortOrder = content.SortOrder;
            contentEntity.Title = content.Title;   

            this.genericRepository.Update(contentEntity);
           await this.genericRepository.SaveChangesAsync();
        }

        public async Task DeleteReferanslarAsync(int contentId)
        {
            var content = await this.GetReferanslarAsync(contentId);
            await this.genericRepository.DeleteAsync<Referanslar>(content);
            await this.genericRepository.SaveChangesAsync();
        } 
    }
}
