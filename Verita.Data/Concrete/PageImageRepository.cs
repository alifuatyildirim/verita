using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class PageImageRepository : IPageImageRepository
    {
        private readonly IGenericRepository genericRepository;
        public PageImageRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddPageImageAsync(PageImage pageImage)
        {
            await this.genericRepository.AddAsync(pageImage);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<PageImage> GetPageImageAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<PageImage>(id);
        }

        public async Task EditPageImageAsync(PageImage pageImage)
        {
            var pageImageEntity = await this.GetPageImageAsync(pageImage.Id);
            if (pageImageEntity == null) 
            {
                return;
            }

            if (pageImage.Image != null) 
            {
                pageImageEntity.Image = pageImage.Image;
            } 
            pageImageEntity.UpdatedDate = DateTime.Now;
            pageImageEntity.UpdatedBy = pageImage.UpdatedBy;

            this.genericRepository.Update(pageImageEntity);
            await this.genericRepository.SaveChangesAsync();
        }

    }
}
