using Verita.Contract.Request.Product;
using Verita.Data.Abstracts;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public class PageImageService : IPageImageService
    { 
        private readonly IPageImageRepository pageImageRepository;
        public PageImageService(IPageImageRepository pageImageRepository)
        { 
            this.pageImageRepository = pageImageRepository;
        }

        public async Task<PageImage> AddPageImageAsync(AddPageImageRequest request)
        {
            var pageImageEntity = new PageImage
            {  
                PageId = request.PageId,
                Image = request.ImageUrl,
            };
            await this.pageImageRepository.AddPageImageAsync(pageImageEntity);
            return pageImageEntity;
        }

        public async Task EditPageImageAsync(EditPageImageRequest pageImage)
        {
            var pageImageEntity = new PageImage
            {
                Id = pageImage.Id!.Value, 
                PageId = pageImage.PageId,
                Image = pageImage.ImageUrl,
            };
            await this.pageImageRepository.EditPageImageAsync(pageImageEntity); 
        }
    }
}
