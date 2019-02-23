using System.Threading.Tasks;
using System.Collections.Generic;

namespace Checkout.Inventory
{
    using Extensions;
    using Interfaces;

    public class ProductService : IProductService, ITransientService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAsync(short countryId)
        {
            var items = await productRepository.GetAsync(countryId, true);

            return items.MapList<Product>();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var item = await productRepository.GetByIdAsync(id);

            return item.Map<Product>();
        }
    }
}
