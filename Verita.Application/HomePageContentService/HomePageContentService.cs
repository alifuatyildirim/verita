using Verita.Application.HomePageSliderService;
using Verita.Application.Image; 
using Verita.Contract.Request.Category;
using Verita.Contract.Request.HomePageContent;
using Verita.Contract.Request.HomePageSlider;
using Verita.Data.Abstracts; 
using Verita.Domain.Entities;

namespace Verita.Application.HomePageContentService
{
    public class HomePageContentService : ImageService, IHomePageContentService
    {
        private readonly IHomePageContentRepository homePageContentRepository;
        public HomePageContentService(IHomePageContentRepository homePageContentRepository)
        {
            this.homePageContentRepository = homePageContentRepository;
        }

        public async Task AddHomePageContentAsync(AddHomePageContentRequest content)
        {
            await this.homePageContentRepository.AddHomePageContentAsync(new HomePageContent
            {
                Title = content.Title,
                Image = content.MainImageUrl,   
                ContentType = content.ContentType,
                CreatedDate = DateTime.Now,
                Description = content.Description,
                Link = content.Link,
            });
        }

        public async Task DeleteHomePageContentAsync(int contentId)
        {
            await this.homePageContentRepository.DeleteHomePageContentAsync(contentId);
        }

        public async Task<List<HomePageContent>> GetHomePageContentListAsync()
        {
            var list = await this.homePageContentRepository.GetHomePageContentsAsync();
            return list.ToList();
        }

        public async Task<HomePageContent> GetHomePageContentAsync(int id)
        {
            return await this.homePageContentRepository.GetHomePageContentAsync(id);
        }


        public async Task UpdateHomePageContentAsync(EditHomePageContentRequest content)
        {
            var basindaBizEntity = new HomePageContent
            {
                Id = content.Id, 
                Title = content.Title,
                Description = content.Description,
                Link = content.Link,
                Image = content.MainImageUrl, 
                ContentType = content.ContentType,
                UpdatedDate = DateTime.Now,  
            };
            await this.homePageContentRepository.UpdateHomePageContentAsync(basindaBizEntity);
        } 
    }
}
