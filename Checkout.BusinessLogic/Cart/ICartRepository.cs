using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Cart
{
    using Models;

    public interface ICartRepository
    {
        /// <summary>
        /// Gets a cart for a given Id reference.
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task<IList<CartEntity>> GetAsync(Guid cartId);

        /// <summary>
        /// Gets an item from a cart by given cart id and product id.
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<CartEntity> GetAsync(Guid cartId, int productId);

        /// <summary>
        /// Removes an instance of a cart.
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task RemoveAsync(Guid cartId);

        /// <summary>
        /// Removes a product on an existing cart.
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        Task RemoveAsync(Guid cartId, int productId);

        /// <summary>
        /// Saves a cart product.null Performs upsert logic based on the existance of an unique id, when 0 add else update.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<CartEntity> SaveAsync(CartEntity item);
    }
}