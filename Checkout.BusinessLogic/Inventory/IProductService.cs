using System.Threading.Tasks;

namespace Checkout.Inventory
{
    public interface IProductService
    {
        Task<Product> GetAsync(short countryId);

        Task<Product> GetByIdAsync(int id);
    }
}