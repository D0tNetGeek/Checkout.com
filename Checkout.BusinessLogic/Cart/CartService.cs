using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Cart
{
    using Checkout.Exceptions;
    using Interfaces;

    public class CartService : ICartService, ITransientService
    {
        private readonly ILogger<CartService> logger;
        private readonly ICartRepository cartRepository;
        private readonly ICountryService countryService;
        private readonly IProductRepository productRepository;

        public CartService(ILogger<CartService> logger,
        ICartRepository cartRepository,
        ICountryService countryService,
        IProductRepository productRepository)
        {
            this.logger = logger;
            this.cartRepository = cartRepository;
            this.countryService = countryService;
            this.productRepository = productRepository;
        }

        public async Task<Cart> GetByIdAsync(Guid cartId)
        {
            try
            {
                var cart = await cartRepository.GetAsync(cartId);

                return Map(cart);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to retrieve cart Id {0}", cartId);

                throw new CartException("Unable to retrieve the cart you have requested. Check the Id.");
            }
        }

        public async Task RemoveAsync(Guid cartId)
        {
            try
            {
                logger.LogDebug("Deleting cart {0}", cartId);

                await cartRepository.RemoveAsync(cartId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to remove cart Id {0}", cartId);

                throw new CartException("Unable to delete the cart. An unexpected error has occured.");
            }
        }

        public async Task RemoveAsync(Guid cartId, int productId)
        {
            try
            {

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to remove cart Id {0}", cartId);

                throw new CartException("Unable to delete the cart. An unexpected error has occured.");
            }
        }

        public async Task<CartProduct> SaveAsync(CartItem item)
        {
            await ValidateProduct(item.CountryId, item.ProductId);

            try
            {
                if (item.CartId.Equals(Guid.Empty))
                {
                    //Is a new cart
                    item.CartId = Guid.NewGuid();
                }

                //Save the product for a cart.
                var map = item.Map<CartEntity>();
                var result = await cartRepository.SaveAsync(map);

                return result.Map<CartProduct>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to save cart item for cart Id {0}, productId {1}, Qty {2}", item.CartId, item.ProductId, item.Qty);

                throw new CartException($"Unable to save product the cart Id. {item.CartId}");
            }
        }

        //Private methods
        Cart Map(IEnumerable<CartEntity> cart)
        {
            if (cart.Count() > 0)
            {
                var map = cart.First().Map<Cart>();             //First item contains main cart detail.
                map.Items = cart.Map<IList<CartProduct>>();     //Create logic product view for cart.

                return map;
            }

            return null;
        }

        async Task ValidateProduct(short countryId, int productId)
        {
            var item = await productRepository.GetByIdAsync(productId);

            if (item == null || item.countryId != countryId)
                throw new CartException("The product is not available for the country specifid");

            return;
        }
    }
}