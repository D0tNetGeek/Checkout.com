using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Checkout.Inventory
{
    using Exceptions;
    using Extensions;
    using Location;

    /// <summary>
    /// A Product object describing a product available as a part of a cart.
    /// /// </summary>
    /// <typeparam name="int"></typeparam>
    public class Product : BaseModel<int>
    {
        /// <summary>
        /// Unique product identfier.
        /// </summary>
        /// <value></value>
        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        /// <summary>
        /// Short description of a product.
        /// </summary>
        /// <value></value>
        [Required]
        [StringLength(250)]
        public string ShortDescription { get; set; }

        [Required]
        public decimal NetPrice { get; set; }

        /// <summary>
        /// Net price of a product.
        /// </summary>
        /// <value></value>
        public string NetPriceFormatted
        {
            get
            {
                return string.Format(new CultureInfo(Country.IsoCode), "{0:C}", NetPrice);
            }
        }

        /// <summary>
        /// Related country product is available for
        /// </summary>
        [Required]

        /// <summary>
        /// Country Model.
        /// </summary>
        /// <value></value>
        public Country Country { get; set; }

        /// <summary>
        /// Tax amount for product (based on country)
        /// </summary>
        public decimal TaxAmount
        {
            get
            {
                if (Country == null)
                    throw new CartException($"A country was not available for product code: {Code}");

                return NetPrice.AsTaxAmount(Country.Tax);
            }
        }

        public string TaxAmountFormatted
        {
            get
            {
                return string.Format(new CultureInfo(Country.IsoCode), "{0:C}", TaxAmount);
            }
        }
    }
}