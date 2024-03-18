using Verita.Contract.Request.Product;
using Verita.Data.Abstracts;
using Verita.Domain.Entities;

namespace Verita.Application.ProductService
{
    public class ProductOrderItemService : IProductOrderItemService
    { 
        private readonly IProductOrderItemRepository productOrderItemRepository;
        public ProductOrderItemService(IProductOrderItemRepository productOrderItemRepository)
        { 
            this.productOrderItemRepository = productOrderItemRepository;
        }

        public async Task<ProductOrderItem> AddProductOrderItemAsync(AddProductOrderItemRequest request)
        {
            var productOrderItemEntity = new ProductOrderItem
            {
                
                Url = request.Url,
                Title = request.Title, 
                ProductId = request.ProductId,
                Image = request.ImageUrl,
            };
            await this.productOrderItemRepository.AddProductOrderItemAsync(productOrderItemEntity);
            return productOrderItemEntity;
        }

        public async Task EditProductOrderItemAsync(EditProductOrderItemRequest productOrderItem)
        {
            var productOrderItemEntity = new ProductOrderItem
            {
                Id = productOrderItem.Id!.Value,
                Url = productOrderItem.Url,
                Title = productOrderItem.Title,
                ProductId = productOrderItem.ProductId,
                Image = productOrderItem.ImageUrl,
            };
            await this.productOrderItemRepository.EditProductOrderItemAsync(productOrderItemEntity); 
        }
    }
}
