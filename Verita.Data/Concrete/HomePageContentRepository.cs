using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class HomePageContentRepository : IHomePageContentRepository
    {
        private readonly IGenericRepository genericRepository;
        public HomePageContentRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddHomePageContentAsync(HomePageContent content)
        {
            await this.genericRepository.AddAsync(content);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<List<HomePageContent>> GetHomePageContentsAsync()
        {
            return await this.genericRepository.GetListAsync<HomePageContent>();
        }
        public async Task<HomePageContent> GetHomePageContentAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<HomePageContent>(id);
        }

        public async Task UpdateHomePageContentAsync(HomePageContent content)
        {
            var contentEntity = await this.GetHomePageContentAsync(content.Id);
            if (contentEntity is null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(content.Image))
            {
                contentEntity.Image = content.Image;
            }
            contentEntity.ContentType = content.ContentType;
            contentEntity.Title = content.Title;  
            contentEntity.Link = content.Link;
            contentEntity.Description = content.Description;

            this.genericRepository.Update(contentEntity);
           await this.genericRepository.SaveChangesAsync();
        }

        public async Task DeleteHomePageContentAsync(int contentId)
        {
            var content = await this.GetHomePageContentAsync(contentId);
            await this.genericRepository.DeleteAsync<HomePageContent>(content);
            await this.genericRepository.SaveChangesAsync();
        }     
    }
}
