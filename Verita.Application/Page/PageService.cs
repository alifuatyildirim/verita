using Verita.Common.Enums;
using Verita.Contract.Request.Product;
using Verita.Data.Abstracts;
using Verita.Data.Migrations;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public class PageService : IPageService
    {
        private readonly IPageRepository pageRepository;
        private readonly IPageImageRepository pageImageRepository;
        public PageService(IPageRepository pageRepository, IPageImageRepository pageImageRepository)
        {
            this.pageRepository = pageRepository;
            this.pageImageRepository = pageImageRepository;
        }

        public async Task<Page> AddPageAsync(AddPageRequest page)
        {
            var pageEntity = new Page
            {
                PageCategory = page.PageCategory,
                CreatedBy = page.CreatedBy, 
                LanguageId = page.LanguageId,
                Description = page.Description,
                Title = page.Title,
                Name = page.Name,
                SortOrder = page.SortOrder,
                BackgroundUrl = page.BackgroundUrl,
            };
            await this.pageRepository.AddPageAsync(pageEntity);
            return pageEntity;
        }

        public async Task<List<Page>> GetPagesAsync()
        {
            return await this.pageRepository.GetPagesAsync();
        }

        public async Task<List<Page>> GetPagesByCategoryAsync(PageCategory pageCategory)
        {
            return await this.pageRepository.GetPagesByCategoryAsync(pageCategory);
        }

        public async Task<Page?> GetPageAsync(int id)
        {
            return await this.pageRepository.GetPageAsync(id);
        }

        public async Task<string> SaveImageAsync(Stream imageStream, string fileName)
        { 
            var sharedFolderPath = Path.Combine("..", "SharedFiles");
             
            if (!Directory.Exists(sharedFolderPath))
            {
                Directory.CreateDirectory(sharedFolderPath);
            } 
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
             
            var filePath = Path.Combine(sharedFolderPath, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageStream.CopyToAsync(fileStream);
            }
             
            return Path.Combine("/SharedFiles", uniqueFileName).Replace("\\", "/");
        }

        public async Task EditPageAsync(EditPageRequest page)
        {
            var pageEntity = new Page
            {
                Id = page.Id,
                PageCategory = page.PageCategory,
                CreatedBy = page.CreatedBy, 
                LanguageId = page.LanguageId,
                Description = page.Description,
                Title = page.Title,
                Name = page.Name,
                BackgroundUrl = page.BackgroundUrl,
                SortOrder = page.SortOrder
            };
            await this.pageRepository.EditPageAsync(pageEntity);
        }
         
    }
}
