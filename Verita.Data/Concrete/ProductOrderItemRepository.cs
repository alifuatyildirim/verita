using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class ProductOrderItemRepository : IProductOrderItemRepository
    {
        private readonly IGenericRepository genericRepository;
        public ProductOrderItemRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddProductOrderItemAsync(ProductOrderItem productOrderItem)
        {
            await this.genericRepository.AddAsync(productOrderItem);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<ProductOrderItem> GetProductOrderItemAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<ProductOrderItem>(id);
        }

        public async Task EditProductOrderItemAsync(ProductOrderItem productOrderItem)
        {
            var productOrderItemEntity = await this.GetProductOrderItemAsync(productOrderItem.Id);
            if (productOrderItemEntity == null) 
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(productOrderItem.Image)) 
            {
                productOrderItemEntity.Image = productOrderItem.Image;
            }
            
            productOrderItemEntity.Title = productOrderItem.Title;
            productOrderItemEntity.ProductId = productOrderItem.ProductId;
            productOrderItemEntity.Url = productOrderItem.Url;
            productOrderItemEntity.UpdatedDate = DateTime.Now;
            productOrderItemEntity.UpdatedBy = productOrderItem.UpdatedBy;

            this.genericRepository.Update(productOrderItemEntity);
            await this.genericRepository.SaveChangesAsync();
        }

    }
}
