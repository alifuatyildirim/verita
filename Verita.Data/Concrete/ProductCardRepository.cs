using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class ProductCardRepository : IProductCardRepository
    {
        private readonly IGenericRepository genericRepository;
        public ProductCardRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddProductCardAsync(ProductCard productCard)
        {
            await this.genericRepository.AddAsync(productCard);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task<ProductCard> GetProductCardAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<ProductCard>(id);
        }

        public async Task EditProductCardAsync(ProductCard productCard)
        {
            var productCardEntity = await this.GetProductCardAsync(productCard.Id);
            if (productCardEntity == null) 
            {
                return;
            }

            if (productCard.Image != null) 
            {
                productCardEntity.Image = productCard.Image;
            }
            productCardEntity.Title = productCard.Title;
            productCardEntity.ProductId = productCard.ProductId;
            productCardEntity.Description = productCard.Description;
            productCardEntity.UpdatedDate = DateTime.Now;
            productCardEntity.UpdatedBy = productCard.UpdatedBy;

            this.genericRepository.Update(productCardEntity);
            await this.genericRepository.SaveChangesAsync();
        }

    }
}
