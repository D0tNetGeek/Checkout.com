using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Location
{
    using Models;

    public interface ICountryRepository
    {
        Task<IList<CountryEntity>> GetAsync(bool? isActive);

        Task<CountryEntity> GetByIdAsync(short id);
    }
}