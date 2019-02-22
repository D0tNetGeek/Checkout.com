using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Cart
{
    using Extensions;

    /// <summary>
    /// Cart object describing a cart logic and items currently associated.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Unique identifier of a cart.
        /// </summary>
        /// <value></value>
        public Guid CartId { get; set; }

        /// <summary>
        /// The country this cart belongs to.
        /// </summary>
        /// <value></value>
        public short CountryId { get; set; }

        /// <summary>
        /// The country ISO language code for the cart.
        /// </summary>
        /// <value></value>
        public string CountryIsoCode { get; set; }

        /// <summary>
        /// The products currently in a cart.
        /// </summary>
        /// <value></value>
        public IEnumerable<CartProduct> Items { get; set; }

        /// <summary>
        /// Total net price of all the products (sum).
        /// </summary>
        /// <value></value>
        public decimal TotalNetPrice
        {
            get
            {
                if (Items != null)
                {
                    return Items.Sum(s => s.TotalNetPrice).Round();
                }
                return 0;
            }
        }

        /// <summary>
        /// Total price in currency format.
        /// </summary>
        /// <value></value>
        public string TotalNetPriceFormatted
        {
            get
            {
                return TotalNetPrice.AsCurrency(CountryIsoCode);
            }
        }

        /// <summary>
        /// Total tax of all the products (sum).
        /// </summary>
        /// <value></value>
        public decimal TotalTax
        {
            get
            {
                if (Items != null)
                {
                    return Items.Sum(s => s.TotalTax).Round();
                }

                return 0;
            }
        }

        /// <summary>
        /// Total gross price of all products (sum).
        /// </summary>
        /// <value></value>
        public decimal TotalGrossPrice
        {
            get
            {
                if (Items != null)
                {
                    Items.Sum(s => s.TotalTax).Round();
                }

                return 0;
            }

        }

        /// <summary>
        /// Total price in currency format.
        /// </summary>
        /// <value></value>
        public string TotalGrossPriceFormatted
        {
            get
            {
                return TotalNetPrice.AsCurrency(CountryIsoCode);
            }
        }

    }
}