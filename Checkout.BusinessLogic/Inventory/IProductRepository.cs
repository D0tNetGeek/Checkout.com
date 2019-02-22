using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Inventory
{
    using Models;

    public interface IProductRepository
    {
        /// <summary>
        /// Gets a list of products based on isactive filter (when supplied).
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        Task<IList<ProductEntity>> GetAsync(short countryId, bool? isActive);

        /// <summary>
        /// Gets an instance of product Id by a given Id reference.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductEntity> GetByIdAsync(int id);
    }
}
