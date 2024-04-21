using Verita.Application.Image;
using Verita.Contract.Request.BasindaBiz; 
using Verita.Domain.Entities;

namespace Verita.Application.BasindaBizService
{
    public interface IBasindaBizService : IImageService
    {
        Task AddCBasindaBizAsync(AddBasindaBizRequest basindaBiz);
        Task DeleteBasindaBizAsync(int basindaBizId);
        Task<List<BasindaBiz>> GetBasindaBizListAsync();
        Task<BasindaBiz> GetBasindaBizAsync(int id);
        Task UpdateBasindaBizAsync(EditBasindaBizRequest basindaBiz);
    }
}
