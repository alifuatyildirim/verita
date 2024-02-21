using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IPageImageRepository
    {
        Task AddPageImageAsync(PageImage pageImage);
        Task EditPageImageAsync(PageImage pageImage);
    }
}
