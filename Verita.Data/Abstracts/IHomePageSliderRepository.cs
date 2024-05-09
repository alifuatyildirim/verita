using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IHomePageSliderRepository
    {
        Task AddHomePageSliderAsync(HomePageSlider slider);
        Task<List<HomePageSlider>> GetHomePageSlidersAsync();
        Task<HomePageSlider> GetHomePageSliderAsync(int id);
        Task UpdateHomePageSliderAsync(HomePageSlider slider);
        Task DeleteHomePageSliderAsync(int sliderId);
    }
}
