using System;
using System.Threading.Tasks;

namespace Checkout.Cart
{
    public interface ICartService
    {
        /// <summary>
        /// Gets a cart by given cart Id.
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task<Cart> GetByIdAsync(Guid cartId);

        /// <summary>
        /// Removes a cart and its associated cart items.
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task RemoveAsync(Guid cartId);

        /// <summary>
        /// Removes a product from a cart.
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task RemoveAsync(Guid cartId, int productId);

        /// <summary>
        /// Saves an item to a cart, if cart Id is not present a new cart is created with the product added.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<CartProduct> SaveAsync(CartItem item);
    }
}