using Verita.Application.HomePageSliderService;
using Verita.Application.Image; 
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageSlider;
using Verita.Data.Abstracts; 
using Verita.Domain.Entities;

namespace Verita.Application.HomePageSliderService
{
    public class HomePageSliderService : ImageService, IHomePageSliderService
    {
        private readonly IHomePageSliderRepository homePageSliderRepository;
        public HomePageSliderService(IHomePageSliderRepository homePageSliderRepository)
        {
            this.homePageSliderRepository = homePageSliderRepository;
        }

        public async Task AddHomePageSliderAsync(AddHomePageSliderRequest slider)
        {
            await this.homePageSliderRepository.AddHomePageSliderAsync(new HomePageSlider
            {
                Name = slider.Name,
                ImageUrl = slider.MainImageUrl,  
                SortOrder = slider.SortOrder, 
                CreatedDate = DateTime.Now,
                Description = slider.Description,
                Link = slider.Link,
            });
        }

        public async Task DeleteHomePageSliderAsync(int sliderId)
        {
            await this.homePageSliderRepository.DeleteHomePageSliderAsync(sliderId);
        }

        public async Task<List<HomePageSlider>> GetHomePageSliderListAsync()
        {
            var list = await this.homePageSliderRepository.GetHomePageSlidersAsync();
            return list.OrderBy(x => x.SortOrder).ToList();
        }

        public async Task<HomePageSlider> GetHomePageSliderAsync(int id)
        {
            return await this.homePageSliderRepository.GetHomePageSliderAsync(id);
        }


        public async Task UpdateHomePageSliderAsync(EditHomePageSliderRequest slider)
        {
            var basindaBizEntity = new HomePageSlider
            {
                Id = slider.Id,
                SortOrder = slider.SortOrder,
                Name = slider.Name,
                Description = slider.Description,
                Link = slider.Link,
                ImageUrl = slider.MainImageUrl, 
                UpdatedDate = DateTime.Now,  
            };
            await this.homePageSliderRepository.UpdateHomePageSliderAsync(basindaBizEntity);
        }   
         
    }
}
