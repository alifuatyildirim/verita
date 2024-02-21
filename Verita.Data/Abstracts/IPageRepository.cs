using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IPageRepository
    {
        Task AddPageAsync(Page page);
        Task EditPageAsync(Page page);
        Task<List<Page>> GetPagesAsync();
        Task<Page?> GetPageAsync(int id); 
    }
}
