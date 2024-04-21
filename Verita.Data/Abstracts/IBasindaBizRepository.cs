using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IBasindaBizRepository
    {
        Task AddBasindaBizAsync(BasindaBiz basindaBiz);
        Task<List<BasindaBiz>> GetBasindaBizListAsync();
        Task<BasindaBiz> GetBasindaBizAsync(int id);
        Task UpdateBasindaBizAsync(BasindaBiz basindaBiz);
        Task DeleteBasindaBizAsync(int basindaBizId);
    }
}
