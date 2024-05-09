using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IHomePageContentRepository
    {
        Task AddHomePageContentAsync(HomePageContent content);
        Task<List<HomePageContent>> GetHomePageContentsAsync();
        Task<HomePageContent> GetHomePageContentAsync(int id);
        Task UpdateHomePageContentAsync(HomePageContent content);
        Task DeleteHomePageContentAsync(int contentId);
    }
}
