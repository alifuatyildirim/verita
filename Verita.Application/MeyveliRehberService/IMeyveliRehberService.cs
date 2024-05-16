using Verita.Application.Image;
using Verita.Contract.Request.MeyveliRehber; 
using Verita.Domain.Entities;

namespace Verita.Application.MeyveliRehberService
{
    public interface IMeyveliRehberService : IImageService
    {
        Task AddMeyveliRehberAsync(AddMeyveliRehberRequest MeyveliRehber);
        Task DeleteMeyveliRehberAsync(int MeyveliRehberId);
        Task<List<MeyveliRehber>> GetMeyveliRehberListAsync();
        Task<MeyveliRehber> GetMeyveliRehberAsync(int id);
        Task UpdateMeyveliRehberAsync(EditMeyveliRehberRequest MeyveliRehber);
    }
}
