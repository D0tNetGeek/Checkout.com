namespace Checkout.Location
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Caching;
    using Interfaces;
    using Location;

    public class CountryService : ICountryService, ITransientService
    {
        private readonly ICacheService cacheService;
        private readonly ICountryRepository countryRepository;

        public CountryService()
        {
            this.cacheService = cacheService;
            this.countryRepository = countryRepository;
        }

        public IList<Country> Get()
        {
            throw new System.NotImplementedException();
        }
        public Task<Country> GetByIdAsync(short id)
        {
            throw new System.NotImplementedException();
        }
    }
}