using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Location
{
    using Extensions;
    using Caching;
    using Interfaces;
    using Location;

    public class CountryService : ICountryService, ITransientService
    {
        private readonly ICacheService cacheService;
        private readonly ICountryRepository countryRepository;

        public CountryService(ICacheService cacheService, ICountryRepository countryRepository)
        {
            this.cacheService = cacheService;
            this.countryRepository = countryRepository;
        }

        public IList<Country> Get()
        {
            return cacheService.Get<IList<Country>>(
                "countries", new Func<IList<Country>>(() =>
                {
                    //get countries
                    var task = countryRepository.GetAsync(true);
                    task.Wait();

                    return task.Result.MapList<Country>();
                })
            );
        }
        public async Task<Country> GetByIdAsync(short id)
        {
            var item = await countryRepository.GetByIdAsync(id);

            return item.Map<Country>();
        }
    }
}