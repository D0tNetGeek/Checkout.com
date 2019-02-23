using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Checkout.Web.Controllers.Api.v1
{
    using Inventory;
    using Checkout.Web.App.Exceptions;

    public class ProductsController : BaseApiController
    {
        private readonly IProductService productService;

        /// <summary>
        /// Product Controller
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Gets a collection of products available for a given countryId
        /// </summary>
        /// <param name="countryId">Required. A countryId to request products for.</param>
        /// <returns>A paged result of products.</returns>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get([FromQuery]short countryId)
        {
            if (countryId == 0)
                throw new ApiException("Country Id must be specified");

            return await productService.GetAsync(countryId);
        }

        /// <summary>
        /// Gets a product by a given productId.
        /// </summary>
        /// <param name="productId">Unique product identifier.</param>
        /// <returns>An instance of a Product object.</returns>
        [HttpGet("{productId}")]
        public async Task<Product> GetProduct(int productId) => await productService.GetByIdAsync(productId);
    }
}