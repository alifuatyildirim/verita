using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class HomePageSliderRepository : IHomePageSliderRepository
    {
        private readonly IGenericRepository genericRepository;
        public HomePageSliderRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddHomePageSliderAsync(HomePageSlider slider)
        {
            await this.genericRepository.AddAsync(slider);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<List<HomePageSlider>> GetHomePageSlidersAsync()
        {
            return await this.genericRepository.GetListAsync<HomePageSlider>();
        }
        public async Task<HomePageSlider> GetHomePageSliderAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<HomePageSlider>(id);
        }

        public async Task UpdateHomePageSliderAsync(HomePageSlider slider)
        {
            var sliderEntity = await this.GetHomePageSliderAsync(slider.Id);
            if (sliderEntity is null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(slider.ImageUrl))
            {
                sliderEntity.ImageUrl = slider.ImageUrl;
            }

            sliderEntity.Name = slider.Name;
            sliderEntity.SortOrder = slider.SortOrder;
            sliderEntity.Link = slider.Link;
            sliderEntity.Description = slider.Description;

            this.genericRepository.Update(sliderEntity);
           await this.genericRepository.SaveChangesAsync();
        }

        public async Task DeleteHomePageSliderAsync(int sliderId)
        {
            var slider = await this.GetHomePageSliderAsync(sliderId);
            await this.genericRepository.DeleteAsync<HomePageSlider>(slider);
            await this.genericRepository.SaveChangesAsync();
        }     
    }
}
