using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IHakkimizdaRepository
    {
        Task AddHakkimizdaAsync(Hakkimizda Hakkimizda);
        Task<Hakkimizda> GetHakkimizdaAsync(int id);
        Task<List<Hakkimizda>> GetAllHakkimizdaAsync();
        Task EditHakkimizdaAsync(Hakkimizda Hakkimizda);
        Task DeleteHakkimizdaAsync(int contentId);
    }
}
