using Verita.Application.Image;
using Verita.Contract.Request.BasindaBiz;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.Referanslar;
using Verita.Contract.Request.HomePageSlider;
using Verita.Domain.Entities;

namespace Verita.Application.HomePageSliderService
{
    public interface IReferanslarService : IImageService
    {
        Task AddReferanslarAsync(AddReferanslarRequest content);
        Task DeleteReferanslarAsync(int contentId);
        Task<List<Referanslar>> GetReferanslarListAsync();
        Task<Referanslar> GetReferanslarAsync(int id);
        Task UpdateReferanslarAsync(EditReferanslarRequest content);
    }
}
