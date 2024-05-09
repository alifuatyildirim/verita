using Verita.Application.Image;
using Verita.Contract.Request.BasindaBiz;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageSlider;
using Verita.Domain.Entities;

namespace Verita.Application.HomePageSliderService
{
    public interface IHomePageSliderService : IImageService
    {
        Task AddHomePageSliderAsync(AddHomePageSliderRequest slider);
        Task DeleteHomePageSliderAsync(int sliderId);
        Task<List<HomePageSlider>> GetHomePageSliderListAsync();
        Task<HomePageSlider> GetHomePageSliderAsync(int id);
        Task UpdateHomePageSliderAsync(EditHomePageSliderRequest slider );
    }
}
