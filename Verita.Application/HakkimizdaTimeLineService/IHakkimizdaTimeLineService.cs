using Verita.Application.Image;
using Verita.Contract.Request.BasindaBiz;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageContent;
using Verita.Contract.Request.HomePageSlider;
using Verita.Domain.Entities;

namespace Verita.Application.HakkimizdaTimeLineService
{
    public interface IHakkimizdaTimeLineService : IImageService
    {
        Task AddHakkimizdaTimeLineAsync(AddHakkimizdaTimeLineRequest content);
        Task DeleteHakkimizdaTimeLineAsync(int contentId);
        Task<List<HakkimizdaTimeLine>> GetHakkimizdaTimeLineListAsync();
        Task<HakkimizdaTimeLine> GetHakkimizdaTimeLineAsync(int id);
        Task UpdateHakkimizdaTimeLineAsync(EditHakkimizdaTimeLineRequest slider );
    }
}
