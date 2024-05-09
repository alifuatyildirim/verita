using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface INedenVeritaRepository
    {
        Task AddNedenVeritaAsync(NedenVerita content);
        Task<List<NedenVerita>> GetNedenVeritaListAsync();
        Task<NedenVerita> GetNedenVeritaAsync(int id);
        Task UpdateNedenVeritaAsync(NedenVerita content);
        Task DeleteNedenVeritaAsync(int contentId);
    }
}
