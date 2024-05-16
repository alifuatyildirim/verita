using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IMeyveliRehberRepository
    {
        Task AddMeyveliRehberAsync(MeyveliRehber MeyveliRehber);
        Task<List<MeyveliRehber>> GetMeyveliRehberListAsync();
        Task<MeyveliRehber> GetMeyveliRehberAsync(int id);
        Task UpdateMeyveliRehberAsync(MeyveliRehber MeyveliRehber);
        Task DeleteMeyveliRehberAsync(int MeyveliRehberId);
    }
}
