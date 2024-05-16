using Verita.Domain.Entities;

namespace Verita.Data.Abstracts
{
    public interface IBunlariBiliyorMusunuzRepository
    {
        Task AddBunlariBiliyorMusunuzAsync(BunlariBiliyorMusunuz content);
        Task<List<BunlariBiliyorMusunuz>> GetBunlariBiliyorMusunuzListAsync();
        Task<BunlariBiliyorMusunuz> GetBunlariBiliyorMusunuzAsync(int id);
        Task<BunlariBiliyorMusunuz?> FindBunlariBiliyorMusunuzAsync(string text);
        Task UpdateBunlariBiliyorMusunuzAsync(BunlariBiliyorMusunuz content);
        Task DeleteBunlariBiliyorMusunuzAsync(int contentId);
    }
}
