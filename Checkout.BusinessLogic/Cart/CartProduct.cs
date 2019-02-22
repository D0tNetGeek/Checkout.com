namespace Checkout.Cart
{
    using Extensions;

    public class CartProduct : CartItem
    {
        /// <summary>
        /// Name of the product.
        /// </summary>
        /// <value></value>
        public string ProductName { get; set; }

        /// <summary>
        /// Unique product code to identify the product.
        /// </summary>
        /// <value></value>
        public string ProductCode { get; set; }

        /// <summary>
        /// Country ISO language code.
        /// </summary>
        /// <value></value>
        public string CountryIsoCode { get; set; }

        /// <summary>
        /// Singular price of the product.
        /// </summary>
        /// <value></value>
        public decimal NetPrice { get; set; }

        public decimal TotalNetPrice
        {
            get { return (Qty * NetPrice).Round(); }
        }

        public string TotalNetPriceFormatted
        {
            get
            {
                return TotalNetPrice.AsCurrency(CountryIsoCode);
            }
        }

        /// <summary>
        /// Singular tax amount of the product (by country).
        /// </summary>
        /// <value></value>
        public decimal TaxAmount { get; set; }

        public decimal TotalTax
        {
            get { return (Qty * TaxAmount).Round(); }
        }

        public string TaxAmountFormatted
        {
            get
            {
                return TaxAmount.AsCurrency(CountryIsoCode);
            }
        }

        /// <summary>
        /// Total gross price for a product, the sum of total net price and total tax.
        /// </summary>
        ///// <value></value>
        public decimal TotalGrossPrice
        {
            get { return (TotalNetPrice + TaxAmount).Round(); }
        }

        public string TotalGrossPriceFormatted
        {
            get
            {
                return TotalGrossPrice.AsCurrency(CountryIsoCode);
            }
        }
    }
}