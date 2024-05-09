using Verita.Application.Image;
using Verita.Contract.Request.BasindaBiz;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageContent;
using Verita.Contract.Request.HomePageSlider;
using Verita.Domain.Entities;

namespace Verita.Application.NedenVeritaService
{
    public interface INedenVeritaService : IImageService
    {
        Task AddNedenVeritaAsync(AddNedenVeritaRequest content);
        Task DeleteNedenVeritaAsync(int contentId);
        Task<List<NedenVerita>> GetNedenVeritaListAsync();
        Task<NedenVerita> GetNedenVeritaAsync(int id);
        Task UpdateNedenVeritaAsync(EditNedenVeritaRequest slider );
    }
}
