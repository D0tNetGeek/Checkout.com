using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Inventory
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAsync(short countryId);

        Task<Product> GetByIdAsync(int id);
    }
}