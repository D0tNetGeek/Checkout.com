using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Location
{
    public interface ICountryService
    {
        /// <summary>
        /// Gets a collection of active countries as a part of the order process.
        /// </summary>
        /// <returns></returns>
        IList<Country> Get();

        /// <summary>
        /// Gets a country bu a given Id reference.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Country> GetByIdAsync(short id);
    }
}