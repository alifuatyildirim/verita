using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class BasindaBizRepository : IBasindaBizRepository
    {
        private readonly IGenericRepository genericRepository;
        public BasindaBizRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddBasindaBizAsync(BasindaBiz basindaBiz)
        {
            await this.genericRepository.AddAsync(basindaBiz);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<List<BasindaBiz>> GetBasindaBizListAsync()
        {
            return await this.genericRepository.GetListAsync<BasindaBiz>();
        }
        public async Task<BasindaBiz> GetBasindaBizAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<BasindaBiz>(id);
        }

        public async Task UpdateBasindaBizAsync(BasindaBiz basindaBiz)
        {
            var basindaBizEntity = await this.GetBasindaBizAsync(basindaBiz.Id);
            if (basindaBizEntity is null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(basindaBiz.Image))
            {
                basindaBizEntity.Image = basindaBiz.Image;
            } 

            basindaBizEntity.Name = basindaBiz.Name;
            basindaBizEntity.DateOfPublication = basindaBiz.DateOfPublication;
            basindaBizEntity.SortOrder = basindaBiz.SortOrder;
            basindaBizEntity.UpdatedBy = basindaBiz.UpdatedBy;
            basindaBizEntity.Link = basindaBiz.Link;
            basindaBizEntity.Resource = basindaBiz.Resource;
            basindaBizEntity.ContentType = basindaBiz.ContentType;
            basindaBizEntity.LabelType = basindaBiz.LabelType;

            this.genericRepository.Update(basindaBizEntity);
           await this.genericRepository.SaveChangesAsync();
        }

        public async Task DeleteBasindaBizAsync(int basindaBizId)
        {
            var basindaBiz = await this.GetBasindaBizAsync(basindaBizId);
            await this.genericRepository.DeleteAsync<BasindaBiz>(basindaBiz);
            await this.genericRepository.SaveChangesAsync();
        }
    }
}
