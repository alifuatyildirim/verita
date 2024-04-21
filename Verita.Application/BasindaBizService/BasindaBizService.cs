using Verita.Application.Image; 
using Verita.Contract.Request.BasindaBiz; 
using Verita.Data.Abstracts; 
using Verita.Domain.Entities;

namespace Verita.Application.BasindaBizService
{
    public class BasindaBizService : ImageService, IBasindaBizService
    {
        private readonly IBasindaBizRepository basindaBizRepository;
        public BasindaBizService(IBasindaBizRepository basindaBizRepository)
        {
            this.basindaBizRepository = basindaBizRepository;
        }

        public async Task AddCBasindaBizAsync(AddBasindaBizRequest basindaBiz)
        {
            await this.basindaBizRepository.AddBasindaBizAsync(new BasindaBiz
            {
                Name = basindaBiz.Name,
                Image = basindaBiz.ImageUrl,
                CreatedBy = basindaBiz.CreatedBy,
                LanguageId = basindaBiz.LanguageId,
                SortOrder = basindaBiz.SortOrder,
                DateOfPublication = basindaBiz.DateOfPublication,
                CreatedDate = DateTime.Now
            });
        }

        public async Task DeleteBasindaBizAsync(int basindaBizId)
        {
            await this.basindaBizRepository.DeleteBasindaBizAsync(basindaBizId);
        }

        public async Task<List<BasindaBiz>> GetBasindaBizListAsync()
        {
            var list = await this.basindaBizRepository.GetBasindaBizListAsync();
            return list.OrderBy(x => x.SortOrder).ToList();
        }

        public async Task<BasindaBiz> GetBasindaBizAsync(int id)
        {
            return await this.basindaBizRepository.GetBasindaBizAsync(id);
        }


        public async Task UpdateBasindaBizAsync(EditBasindaBizRequest basindaBiz)
        {
            var basindaBizEntity = new BasindaBiz
            {
                Id = basindaBiz.Id,
                SortOrder = basindaBiz.SortOrder,
                Name = basindaBiz.Name,
                LanguageId = basindaBiz.LanguageId,
                Image = basindaBiz.ImageUrl, 
                UpdatedDate = DateTime.Now, 
                DateOfPublication = basindaBiz.DateOfPublication,
            };
            await this.basindaBizRepository.UpdateBasindaBizAsync(basindaBizEntity);
        }
    }
}
