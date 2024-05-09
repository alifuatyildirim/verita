using Verita.Application.Image;
using Verita.Contract.Request.BasindaBiz;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageContent;
using Verita.Contract.Request.HomePageSlider;
using Verita.Domain.Entities;

namespace Verita.Application.HomePageSliderService
{
    public interface IHomePageContentService : IImageService
    {
        Task AddHomePageContentAsync(AddHomePageContentRequest content);
        Task DeleteHomePageContentAsync(int contentId);
        Task<List<HomePageContent>> GetHomePageContentListAsync();
        Task<HomePageContent> GetHomePageContentAsync(int id);
        Task UpdateHomePageContentAsync(EditHomePageContentRequest content);
    }
}
