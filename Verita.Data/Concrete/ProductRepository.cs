using Verita.Data.Abstracts;
using Verita.Domain.Entities;
using Verita.Repository.Mssql.GenericRepository;

namespace Verita.Data.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IGenericRepository genericRepository;
        public ProductRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddProductAsync(Product product)
        {
            await this.genericRepository.AddAsync(product);
            await this.genericRepository.SaveChangesAsync();    
        }
    }
}
