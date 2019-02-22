using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Location
{
    using EF;
    using Interfaces;
    using Models;

    /// <summary>
    /// Repository for CRUD country related queries.
    /// </summary>
    public class CountryRepository : ICountryRepository, ITransientService
    {
        private readonly CheckoutContext context;

        public CountryRepository(CheckoutContext context)
        {
            this.context = context;
        }

        public async Task<IList<CountryEntity>> GetAsync(bool? isActive)
        {
            return await context
            .Country
            .Where(w => isActive == null || w.IsActive == (bool)isActive)
            .ToListAsync();
        }

        public async Task<CountryEntity> GetByIdAsync(short id)
        {
            return await context.Country.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}