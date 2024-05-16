using Verita.Application.HomePageSliderService;
using Verita.Application.Image;
using Verita.Contract.Request.BunlariBiliyorMusunuz;
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageContent;
using Verita.Contract.Request.HomePageSlider;
using Verita.Data.Abstracts; 
using Verita.Domain.Entities;

namespace Verita.Application.BunlariBiliyorMusunuzService
{
    public class BunlariBiliyorMusunuzService : ImageService, IBunlariBiliyorMusunuzService
    {
        private readonly IBunlariBiliyorMusunuzRepository BunlariBiliyorMusunuzRepository;
        public BunlariBiliyorMusunuzService(IBunlariBiliyorMusunuzRepository BunlariBiliyorMusunuzRepository)
        {
            this.BunlariBiliyorMusunuzRepository = BunlariBiliyorMusunuzRepository;
        }

        public async Task AddBunlariBiliyorMusunuzAsync(AddBunlariBiliyorMusunuzRequest content)
        {
            await this.BunlariBiliyorMusunuzRepository.AddBunlariBiliyorMusunuzAsync(new BunlariBiliyorMusunuz
            {
                Title = content.Title,
                SortOrder = content.SortOrder,
                CreatedDate = DateTime.Now,
                Description = content.Description,
                IsActive = content.IsActive,
            });
        }

        public async Task DeleteBunlariBiliyorMusunuzAsync(int contentId)
        {
            await this.BunlariBiliyorMusunuzRepository.DeleteBunlariBiliyorMusunuzAsync(contentId);
        }

        public async Task<List<BunlariBiliyorMusunuz>> GetBunlariBiliyorMusunuzListAsync()
        {
            var list = await this.BunlariBiliyorMusunuzRepository.GetBunlariBiliyorMusunuzListAsync();
            return list.Where(x => x.IsActive).OrderBy(x => x.SortOrder).ToList();
        }

        public async Task<BunlariBiliyorMusunuz> GetBunlariBiliyorMusunuzAsync(int id)
        {
            return await this.BunlariBiliyorMusunuzRepository.GetBunlariBiliyorMusunuzAsync(id);
        }


        public async Task UpdateBunlariBiliyorMusunuzAsync(EditBunlariBiliyorMusunuzRequest content)
        {
            var basindaBizEntity = new BunlariBiliyorMusunuz
            {
                Id = content.Id,
                SortOrder = content.SortOrder,
                Title = content.Title,
                Description = content.Description,
                UpdatedDate = DateTime.Now,
                IsActive = content.IsActive
            };
            await this.BunlariBiliyorMusunuzRepository.UpdateBunlariBiliyorMusunuzAsync(basindaBizEntity);
        }

        public async Task<BunlariBiliyorMusunuz?> FindBunlariBiliyorMusunuzAsync(string text)
        {
            return await this.BunlariBiliyorMusunuzRepository.FindBunlariBiliyorMusunuzAsync(text);
        }
    }
}
