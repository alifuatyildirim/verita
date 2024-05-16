using Verita.Application.Image;
using Verita.Contract.Request.Hakkimizda;
using Verita.Contract.Request.HomePageContent;
using Verita.Domain.Entities;

namespace Verita.Application.HakkimizdaService
{
    public interface IHakkimizdaService : IImageService
    {
        Task AddHakkimizdaAsync(AddHakkimizdaRequest content);
        Task DeleteHakkimizdaAsync(int contentId);
        Task<List<Hakkimizda>> GetHakkimizdaListAsync();
        Task<Hakkimizda> GetHakkimizdaAsync(int id);
        Task UpdateHakkimizdaAsync(EditHakkimizdaRequest content);
    }
}
