using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IReferanslarRepository
    {
        Task AddReferanslarAsync(Referanslar content);
        Task<List<Referanslar>> GetReferanslarListAsync();
        Task<Referanslar> GetReferanslarAsync(int id);
        Task UpdateReferanslarAsync(Referanslar content);
        Task DeleteReferanslarAsync(int contentId);
    }
}
