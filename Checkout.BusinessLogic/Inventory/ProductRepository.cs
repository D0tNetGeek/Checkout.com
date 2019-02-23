using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Inventory
{
    using EF;
    using Interfaces;
    using Models;

    /// <summary>
    /// Repository for CRUD product related queries.
    /// </summary>
    public class ProductRepository : IProductRepository, ITransientService
    {
        private readonly CheckoutContext context;

        public ProductRepository(CheckoutContext context)
        {
            this.context = context;
        }

        public async Task<IList<ProductEntity>> GetAsync(short countryId, bool? isActive)
        {
            var productList = await context
                .Product
                .Include(products => products.Country)
                .Where(w => w.CountryId == countryId && (isActive == null || w.IsActive == (bool)isActive))
                .ToListAsync();

            return productList;
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
            var product = await context
                .Product
                .Include(products => products.Country)
                .FirstOrDefaultAsync(f => f.Id == id);

            return product;
        }
    }
}
