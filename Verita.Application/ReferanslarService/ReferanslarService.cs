using Verita.Application.HomePageSliderService;
using Verita.Application.Image; 
using Verita.Contract.Request.Category;
using Verita.Contract.Request.Referanslar;
using Verita.Contract.Request.HomePageSlider;
using Verita.Data.Abstracts; 
using Verita.Domain.Entities;

namespace Verita.Application.ReferanslarService
{
    public class ReferanslarService : ImageService, IReferanslarService
    {
        private readonly IReferanslarRepository ReferanslarRepository;
        public ReferanslarService(IReferanslarRepository ReferanslarRepository)
        {
            this.ReferanslarRepository = ReferanslarRepository;
        }

        public async Task AddReferanslarAsync(AddReferanslarRequest content)
        {
            await this.ReferanslarRepository.AddReferanslarAsync(new Referanslar
            {
                Title = content.Title,
                Image = content.MainImageUrl,   
                CreatedDate = DateTime.Now, 
                SortOrder = content.SortOrder
            });
        }

        public async Task DeleteReferanslarAsync(int contentId)
        {
            await this.ReferanslarRepository.DeleteReferanslarAsync(contentId);
        }

        public async Task<List<Referanslar>> GetReferanslarListAsync()
        {
            var list = await this.ReferanslarRepository.GetReferanslarListAsync();
            return list.ToList();
        }

        public async Task<Referanslar> GetReferanslarAsync(int id)
        {
            return await this.ReferanslarRepository.GetReferanslarAsync(id);
        }


        public async Task UpdateReferanslarAsync(EditReferanslarRequest content)
        {
            var basindaBizEntity = new Referanslar
            {
                Id = content.Id, 
                Title = content.Title, 
                Image = content.MainImageUrl,  
                UpdatedDate = DateTime.Now,  
                SortOrder = content.SortOrder,
            };
            await this.ReferanslarRepository.UpdateReferanslarAsync(basindaBizEntity);
        } 
    }
}
