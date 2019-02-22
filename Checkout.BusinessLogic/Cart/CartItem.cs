using System;
using System.ComponentModel.DataAnnotations;

namespace Checkout.Cart
{
    /// <summary>
    /// Cart object which defines the minimum requirements for a valid cart item (product).
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Unique Id of an existing cart to update.
        /// When empty a new cart is create (Guid.Empty = 00000000-0000-0000-0000-000000000000)
        /// </summary>
        /// <value></value>
        public Guid CartId { get; set; } = Guid.Empty;

        /// <summary>
        /// Country the cart item belongs to.
        /// </summary>
        /// <value></value>
        [Required]
        [Range(1, short.MaxValue, ErrorMessage = "CountryId must be set.")]
        public short CountryId { get; set; }

        /// <summary>
        /// Cart item (product) to add/update
        /// </summary>
        /// <value></value>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A minimum quantity of 1 must be added.")]
        public int ProductId { get; set; }

        /// <summary>
        /// The quantity to add/update for a given cart item (product).
        /// </summary>
        /// <value></value>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A minimum quantity of 1 must be entered.")]
        public int Qty { get; set; }
    }
}