using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class HakkimizdaRepository : IHakkimizdaRepository
    {
        private readonly IGenericRepository genericRepository;
        public HakkimizdaRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddHakkimizdaAsync(Hakkimizda Hakkimizda)
        {
            await this.genericRepository.AddAsync(Hakkimizda);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<Hakkimizda> GetHakkimizdaAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<Hakkimizda>(id);
        }

        public async Task<List<Hakkimizda>> GetAllHakkimizdaAsync()
        {
            return await this.genericRepository.GetListAsync<Hakkimizda>();
        }

        public async Task EditHakkimizdaAsync(Hakkimizda Hakkimizda)
        {
            var HakkimizdaEntity = await this.GetHakkimizdaAsync(Hakkimizda.Id);
            if (HakkimizdaEntity == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(Hakkimizda.ImageUrl1))
            {
                HakkimizdaEntity.ImageUrl1 = Hakkimizda.ImageUrl1;
            }

            if (!string.IsNullOrWhiteSpace(Hakkimizda.ImageUrl2))
            {
                HakkimizdaEntity.ImageUrl2 = Hakkimizda.ImageUrl2;
            }

            if (!string.IsNullOrWhiteSpace(Hakkimizda.BackgroundImageUrl))
            {
                HakkimizdaEntity.BackgroundImageUrl = Hakkimizda.BackgroundImageUrl;
            }



            HakkimizdaEntity.Description1 = Hakkimizda.Description1;
            HakkimizdaEntity.Title1 = Hakkimizda.Title1;
            HakkimizdaEntity.Description2 = Hakkimizda.Description2;
            HakkimizdaEntity.Title2 = Hakkimizda.Title2;
            HakkimizdaEntity.Description3 = Hakkimizda.Description3;
            HakkimizdaEntity.Title3 = Hakkimizda.Title3;
            HakkimizdaEntity.SortOrder = Hakkimizda.SortOrder;
            HakkimizdaEntity.UpdatedDate = DateTime.Now;
            HakkimizdaEntity.UpdatedBy = Hakkimizda.UpdatedBy;

            this.genericRepository.Update(HakkimizdaEntity);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task DeleteHakkimizdaAsync(int contentId)
        {
            var content = await this.GetHakkimizdaAsync(contentId);
            await this.genericRepository.DeleteAsync<Hakkimizda>(content);
            await this.genericRepository.SaveChangesAsync();
        }
    }
}
