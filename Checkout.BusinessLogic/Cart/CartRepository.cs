using System;
using System.Threading.Tasks;

namespace Checkout.Cart
{
    using EF;
    using Interfaces;
    using Models;

    public class CartRepository : ICartRepository, ITransientService
    {
        private readonly CheckoutContext context;

        public CartRepository(CheckoutContext context)
        {
            this.context = context;
        }

        public async Task<System.Collections.Generic.IList<CartEntity>> GetAsync(Guid cartId)
        {
            throw new NotImplementedException();
        }

        public Task<CartEntity> GetAsync(Guid cartId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid cartId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid cartId, int product)
        {
            throw new NotImplementedException();
        }

        public Task<CartEntity> SaveAsync(CartEntity item)
        {
            throw new NotImplementedException();
        }
    }
}