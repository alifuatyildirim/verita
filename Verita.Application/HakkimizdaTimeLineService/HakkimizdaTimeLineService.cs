using Verita.Application.HomePageSliderService;
using Verita.Application.Image; 
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageContent;
using Verita.Contract.Request.HomePageSlider;
using Verita.Data.Abstracts; 
using Verita.Domain.Entities;

namespace Verita.Application.HakkimizdaTimeLineService
{
    public class HakkimizdaTimeLineService : ImageService, IHakkimizdaTimeLineService
    {
        private readonly IHakkimizdaTimeLineRepository HakkimizdaTimeLineRepository;
        public HakkimizdaTimeLineService(IHakkimizdaTimeLineRepository HakkimizdaTimeLineRepository)
        {
            this.HakkimizdaTimeLineRepository = HakkimizdaTimeLineRepository;
        }

        public async Task AddHakkimizdaTimeLineAsync(AddHakkimizdaTimeLineRequest content)
        {
            await this.HakkimizdaTimeLineRepository.AddHakkimizdaTimeLineAsync(new HakkimizdaTimeLine
            {
                Year = content.Year, 
                IsActive = content.IsActive,
                SortOrder = content.SortOrder, 
                CreatedDate = DateTime.Now,
                Description = content.Description, 

            });
        }

        public async Task DeleteHakkimizdaTimeLineAsync(int contentId)
        {
            await this.HakkimizdaTimeLineRepository.DeleteHakkimizdaTimeLineAsync(contentId);
        }

        public async Task<List<HakkimizdaTimeLine>> GetHakkimizdaTimeLineListAsync()
        {
            var list = await this.HakkimizdaTimeLineRepository.GetHakkimizdaTimeLineListAsync();
            return list.OrderBy(x => x.SortOrder).ToList();
        }

        public async Task<HakkimizdaTimeLine> GetHakkimizdaTimeLineAsync(int id)
        {
            return await this.HakkimizdaTimeLineRepository.GetHakkimizdaTimeLineAsync(id);
        }


        public async Task UpdateHakkimizdaTimeLineAsync(EditHakkimizdaTimeLineRequest content)
        {
            var basindaBizEntity = new HakkimizdaTimeLine
            {
                Id = content.Id,
                SortOrder = content.SortOrder, 
                Description = content.Description, 
                Year = content.Year, 
                UpdatedDate = DateTime.Now,  
            };
            await this.HakkimizdaTimeLineRepository.UpdateHakkimizdaTimeLineAsync(basindaBizEntity);
        }

    }
}
