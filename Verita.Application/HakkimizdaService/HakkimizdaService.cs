using Verita.Application.HomePageSliderService;
using Verita.Application.Image;
using Verita.Contract.Request.Hakkimizda;
using Verita.Contract.Request.HomePageContent; 
using Verita.Data.Abstracts; 
using Verita.Domain.Entities;

namespace Verita.Application.HakkimizdaService
{
    public class HakkimizdaService : ImageService, IHakkimizdaService
    {
        private readonly IHakkimizdaRepository HakkimizdaRepository;
        public HakkimizdaService(IHakkimizdaRepository HakkimizdaRepository)
        {
            this.HakkimizdaRepository = HakkimizdaRepository;
        }

        public async Task AddHakkimizdaAsync(AddHakkimizdaRequest content)
        {
            await this.HakkimizdaRepository.AddHakkimizdaAsync(new Hakkimizda
            {
                Title1 = content.Title1,
                Title2 = content.Title2,
                Title3 = content.Title3,
                Description3 = content.Description3,
                ImageUrl2 = content.ImageUrl2,
                ImageUrl1 = content.ImageUrl1,
                Description2 = content.Description2,
                Description1 = content.Description1,
                BackgroundImageUrl = content.BackgroundImageUrl,
                SortOrder = content.SortOrder,
            });
        }

        public async Task DeleteHakkimizdaAsync(int contentId)
        {
            await this.HakkimizdaRepository.DeleteHakkimizdaAsync(contentId);
        }

        public async Task<List<Hakkimizda>> GetHakkimizdaListAsync()
        {
            var list = await this.HakkimizdaRepository.GetAllHakkimizdaAsync();
            return list.ToList();
        }

        public async Task<Hakkimizda> GetHakkimizdaAsync(int id)
        {
            return await this.HakkimizdaRepository.GetHakkimizdaAsync(id);
        }


        public async Task UpdateHakkimizdaAsync(EditHakkimizdaRequest content)
        {
            var basindaBizEntity = new Hakkimizda
            {
                Id = content.Id,
                Title1 = content.Title1,
                Title2 = content.Title2,
                Title3 = content.Title3,
                Description3 = content.Description3,
                SortOrder = content.SortOrder,
                BackgroundImageUrl = content.BackgroundImageUrl,
                Description1 = content.Description1,
                Description2 = content.Description2,
                ImageUrl1 = content.ImageUrl1,
                ImageUrl2 = content.ImageUrl2,
                UpdatedDate = DateTime.Now,  
            };
            await this.HakkimizdaRepository.EditHakkimizdaAsync(basindaBizEntity);
        }

    }
}
