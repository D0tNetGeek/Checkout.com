using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public async Task<IList<CartEntity>> GetAsync(Guid cartId)
        {
            return await context.Cart
                .Include(i => i.Product)
                .Include(i => i.Country)
                .Where(w => w.CartId == cartId).ToListAsync();
        }

        public async Task<CartEntity> GetAsync(Guid cartId, int productId)
        {
            return await context.Cart
                .Include(i => i.Product)
                .Include(i => i.Country)
                .FirstOrDefaultAsync(f => f.CartId == cartId && f.ProductId == productId);
        }

        public async Task RemoveAsync(Guid cartId)
        {
            var items = context.Cart.Where(w => w.CartId == cartId);

            context.Cart.RemoveRange(items);

            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid cartId, int productId)
        {
            var match = await context.Cart.FirstOrDefaultAsync(f => f.CartId == cartId && f.ProductId == productId);

            if (match != null)
            {
                context.Cart.Remove(match);

                await context.SaveChangesAsync();
            }
        }

        public async Task<CartEntity> SaveAsync(CartEntity item)
        {
            var existing = await GetAsync(item.CartId, item.ProductId);

            if (existing != null)
            {
                existing.Qty = item.Qty;

                context.Cart.Update(existing);
            }
            else
            {
                //add new
                await context.Cart.AddAsync(item);
            }

            await context.SaveChangesAsync();

            //get the record to ensure price reflects true values with FK relationships in place.
            return await GetAsync(item.CartId, item.ProductId);
        }
    }
}