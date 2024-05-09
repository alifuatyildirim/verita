using Verita.Application.HomePageSliderService;
using Verita.Application.Image; 
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageContent;
using Verita.Contract.Request.HomePageSlider;
using Verita.Data.Abstracts; 
using Verita.Domain.Entities;

namespace Verita.Application.NedenVeritaService
{
    public class NedenVeritaService : ImageService, INedenVeritaService
    {
        private readonly INedenVeritaRepository nedenVeritaRepository;
        public NedenVeritaService(INedenVeritaRepository nedenVeritaRepository)
        {
            this.nedenVeritaRepository = nedenVeritaRepository;
        }

        public async Task AddNedenVeritaAsync(AddNedenVeritaRequest content)
        {
            await this.nedenVeritaRepository.AddNedenVeritaAsync(new NedenVerita
            {
                Title = content.Title, 
                SortOrder = content.SortOrder, 
                CreatedDate = DateTime.Now,
                Description = content.Description, 
                Name = content.Name, 
                City = content.City, 
            });
        }

        public async Task DeleteNedenVeritaAsync(int contentId)
        {
            await this.nedenVeritaRepository.DeleteNedenVeritaAsync(contentId);
        }

        public async Task<List<NedenVerita>> GetNedenVeritaListAsync()
        {
            var list = await this.nedenVeritaRepository.GetNedenVeritaListAsync();
            return list.OrderBy(x => x.SortOrder).ToList();
        }

        public async Task<NedenVerita> GetNedenVeritaAsync(int id)
        {
            return await this.nedenVeritaRepository.GetNedenVeritaAsync(id);
        }


        public async Task UpdateNedenVeritaAsync(EditNedenVeritaRequest content)
        {
            var basindaBizEntity = new NedenVerita
            {
                Id = content.Id,
                SortOrder = content.SortOrder,
                Title = content.Title,
                Description = content.Description, 
                Name = content.Name, 
                City = content.City, 
                UpdatedDate = DateTime.Now,  
            };
            await this.nedenVeritaRepository.UpdateNedenVeritaAsync(basindaBizEntity);
        }

    }
}
