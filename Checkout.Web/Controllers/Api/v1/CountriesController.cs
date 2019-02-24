using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Web.Controllers.Api.v1
{
    using Location;

    /// <summary>
    /// Countries REST API.static Endpoints for country specific data.
    /// </summary>
    [ApiVersion("1.0")]
    public class CountriesController : BaseApiController
    {
        private ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        /// <summary>
        /// Gets a collection of countries available for order process.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Country> Get() => countryService.Get();

        /// <summary>
        /// Gets a country by a given countryId
        /// </summary>
        /// <param name="countryId">A given country Id to search for.</param>
        /// <returns>An object of Country, when found.</returns>
        [HttpGet("{countryId}")]
        public async Task<Country> Get(short countryId) => await countryService.GetByIdAsync(countryId);
    }
}