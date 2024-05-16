using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class MeyveliRehberRepository : IMeyveliRehberRepository
    {
        private readonly IGenericRepository genericRepository;
        public MeyveliRehberRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddMeyveliRehberAsync(MeyveliRehber MeyveliRehber)
        {
            await this.genericRepository.AddAsync(MeyveliRehber);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<List<MeyveliRehber>> GetMeyveliRehberListAsync()
        {
            return await this.genericRepository.GetListAsync<MeyveliRehber>();
        }
        public async Task<MeyveliRehber> GetMeyveliRehberAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<MeyveliRehber>(id);
        }

        public async Task UpdateMeyveliRehberAsync(MeyveliRehber MeyveliRehber)
        {
            var MeyveliRehberEntity = await this.GetMeyveliRehberAsync(MeyveliRehber.Id);
            if (MeyveliRehberEntity is null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(MeyveliRehber.Image))
            {
                MeyveliRehberEntity.Image = MeyveliRehber.Image;
            } 

            MeyveliRehberEntity.Name = MeyveliRehber.Name;
            MeyveliRehberEntity.File = MeyveliRehber.File;
            MeyveliRehberEntity.DateOfPublication = MeyveliRehber.DateOfPublication;
            MeyveliRehberEntity.SortOrder = MeyveliRehber.SortOrder;
            MeyveliRehberEntity.UpdatedBy = MeyveliRehber.UpdatedBy;
            MeyveliRehberEntity.Link = MeyveliRehber.Link;
            MeyveliRehber.MeyveliRehberType = MeyveliRehber.MeyveliRehberType;

            this.genericRepository.Update(MeyveliRehberEntity);
           await this.genericRepository.SaveChangesAsync();
        }

        public async Task DeleteMeyveliRehberAsync(int MeyveliRehberId)
        {
            var MeyveliRehber = await this.GetMeyveliRehberAsync(MeyveliRehberId);
            await this.genericRepository.DeleteAsync<MeyveliRehber>(MeyveliRehber);
            await this.genericRepository.SaveChangesAsync();
        }
    }
}
