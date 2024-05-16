using Verita.Application.Image; 
using Verita.Contract.Request.MeyveliRehber; 
using Verita.Data.Abstracts; 
using Verita.Domain.Entities;

namespace Verita.Application.MeyveliRehberService
{
    public class MeyveliRehberService : ImageService, IMeyveliRehberService
    {
        private readonly IMeyveliRehberRepository MeyveliRehberRepository;
        public MeyveliRehberService(IMeyveliRehberRepository MeyveliRehberRepository)
        {
            this.MeyveliRehberRepository = MeyveliRehberRepository;
        }

        public async Task AddMeyveliRehberAsync(AddMeyveliRehberRequest MeyveliRehber)
        {
            await this.MeyveliRehberRepository.AddMeyveliRehberAsync(new MeyveliRehber
            {
                Name = MeyveliRehber.Name,
                Image = MeyveliRehber.ImageUrl,
                CreatedBy = MeyveliRehber.CreatedBy,
                LanguageId = MeyveliRehber.LanguageId,
                SortOrder = MeyveliRehber.SortOrder,
                DateOfPublication = MeyveliRehber.DateOfPublication,
                Link = MeyveliRehber.Link,
                File = MeyveliRehber.FileUrl, 
                CreatedDate = DateTime.Now
            });
        }

        public async Task DeleteMeyveliRehberAsync(int MeyveliRehberId)
        {
            await this.MeyveliRehberRepository.DeleteMeyveliRehberAsync(MeyveliRehberId);
        }

        public async Task<List<MeyveliRehber>> GetMeyveliRehberListAsync()
        {
            var list = await this.MeyveliRehberRepository.GetMeyveliRehberListAsync();
            return list.OrderBy(x => x.SortOrder).ToList();
        }

        public async Task<MeyveliRehber> GetMeyveliRehberAsync(int id)
        {
            return await this.MeyveliRehberRepository.GetMeyveliRehberAsync(id);
        }


        public async Task UpdateMeyveliRehberAsync(EditMeyveliRehberRequest MeyveliRehber)
        {
            var MeyveliRehberEntity = new MeyveliRehber
            {
                Id = MeyveliRehber.Id,
                SortOrder = MeyveliRehber.SortOrder,
                Name = MeyveliRehber.Name,
                LanguageId = MeyveliRehber.LanguageId,
                Image = MeyveliRehber.ImageUrl, 
                UpdatedDate = DateTime.Now, 
                DateOfPublication = MeyveliRehber.DateOfPublication,
                Link = MeyveliRehber.Link, 
                File = MeyveliRehber.FileUrl
            };
            await this.MeyveliRehberRepository.UpdateMeyveliRehberAsync(MeyveliRehberEntity);
        }
    }
}
