using Verita.Application.Image;
using Verita.Contract.Request.BasindaBiz;
using Verita.Contract.Request.BunlariBiliyorMusunuz;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageContent;
using Verita.Contract.Request.HomePageSlider;
using Verita.Domain.Entities;

namespace Verita.Application.BunlariBiliyorMusunuzService
{
    public interface IBunlariBiliyorMusunuzService : IImageService
    {
        Task AddBunlariBiliyorMusunuzAsync(AddBunlariBiliyorMusunuzRequest content);
        Task DeleteBunlariBiliyorMusunuzAsync(int contentId);
        Task<List<BunlariBiliyorMusunuz>> GetBunlariBiliyorMusunuzListAsync();
        Task<BunlariBiliyorMusunuz> GetBunlariBiliyorMusunuzAsync(int id);
        Task<BunlariBiliyorMusunuz?> FindBunlariBiliyorMusunuzAsync(string text);
        Task UpdateBunlariBiliyorMusunuzAsync(EditBunlariBiliyorMusunuzRequest slider );
    }
}
