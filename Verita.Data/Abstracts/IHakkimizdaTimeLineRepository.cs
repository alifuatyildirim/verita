using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IHakkimizdaTimeLineRepository
    {
        Task AddHakkimizdaTimeLineAsync(HakkimizdaTimeLine content);
        Task<List<HakkimizdaTimeLine>> GetHakkimizdaTimeLineListAsync();
        Task<HakkimizdaTimeLine> GetHakkimizdaTimeLineAsync(int id);
        Task UpdateHakkimizdaTimeLineAsync(HakkimizdaTimeLine content);
        Task DeleteHakkimizdaTimeLineAsync(int contentId);
    }
}
