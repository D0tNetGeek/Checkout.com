using System;
using System.Net.Http;

namespace Checkout.Web.Console
{
    using Client;

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. Start Checkout.Web in browser without debug mode.
             * 2. Set Checkout.Web.Console as startup project and run.
             * 3. Debug the console app by putting breakpoints.
             * 4. Change the port number as exposed during runtime.
             */
            var checkoutClient = new Client("http://localhost:50174/", new HttpClient());

            //Get products
            var products = checkoutClient.ProductsGetAsync(1, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("Products");

            foreach (var product in products)
            {
                System.Console.WriteLine($"Product Id: {product.Id}, Code: {product.Code}, Name: {product.Name}, NetPrice: {product.NetPrice}");
            }

            //Get product by Id
            var productById = checkoutClient.GetProductByProductId(1, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("Product by Product Id ");
            System.Console.WriteLine($"Product Id: {productById.Id}, Code: {productById.Code}, Name: {productById.Name}, NetPrice: {productById.NetPrice}");

            // get countries 
            var countries = checkoutClient.CountriesGetAsync("1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("Countries");

            foreach (var country in countries)
            {
                System.Console.WriteLine($"Country Id: {country.Id}, IsoCode: {country.IsoCode}, Name: {country.Name}, Currency: {country.CurrencySymbol}");
            }

            // get country by Id 
            var countryById = checkoutClient.GetCountryByCountryId(2, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("Country by Country Id");
            System.Console.WriteLine($"Country Id: {countryById.Id}, IsoCode: {countryById.IsoCode}, Name: {countryById.Name}, Currency: {countryById.CurrencySymbol}");

            // create a new cart with a product
            var cartProduct = checkoutClient.SaveCartAsync(Guid.Empty, 2, 4, 2, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("Add new product to the cart");
            System.Console.WriteLine($"Cart Id: {cartProduct.CartId}, Product Id: {cartProduct.ProductId}, Qty: {cartProduct.Qty}, Net Price: {cartProduct.TotalNetPriceFormatted}, Tax: {cartProduct.TaxAmountFormatted}, Gross Price: {cartProduct.TotalGrossPriceFormatted}");

            // get a cart
            var cart = checkoutClient.CartByCartIdGetAsync((Guid)cartProduct.CartId, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("Get cart by cart Id");
            System.Console.WriteLine($"Cart Id: {cart.CartId}, Country IsoCode: {cart.CountryIsoCode}, Item Count: {cart.Items.Count}");

            // update a cart with a product
            cartProduct = checkoutClient.SaveCartAsync(cartProduct.CartId, 2, 5, 3, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("Update Cart");
            System.Console.WriteLine($"Cart Id: {cartProduct.CartId}, Product Id: {cartProduct.ProductId}, Qty: {cartProduct.Qty}, Net Price: {cartProduct.TotalNetPriceFormatted}, Tax: {cartProduct.TaxAmountFormatted}, Gross Price: {cartProduct.TotalGrossPriceFormatted}");

            // get a cart
            cart = checkoutClient.CartByCartIdGetAsync((Guid)cartProduct.CartId, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("Get Cart by Cart Id");
            System.Console.WriteLine($"Cart Id: {cart.CartId}, Country IsoCode: {cart.CountryIsoCode}, Item Count: {cart.Items.Count}");

            System.Console.WriteLine("");
            System.Console.WriteLine("Delete Cart by Cart Id and Product Id");

            // delete cart product
            checkoutClient.DeleteCartByCartIdProductId((Guid)cartProduct.CartId, 4, "1.0").GetAwaiter().GetResult();
            System.Console.WriteLine($"Deleted: CartId: {cartProduct.CartId}, product Id 4");

            // get a cart
            cart = checkoutClient.CartByCartIdGetAsync((Guid)cartProduct.CartId, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("#Get Cart by Cart Id");
            System.Console.WriteLine($"Cart Id: {cart.CartId}, Country IsoCode: {cart.CountryIsoCode}, Item Count: {cart.Items.Count}");

            System.Console.WriteLine("");
            System.Console.WriteLine("Delete Cart");

            // delete cart
            checkoutClient.DeleteCartByIdAsync((Guid)cartProduct.CartId, "1.0").GetAwaiter().GetResult();
            System.Console.WriteLine($"Deleted: CartId {cartProduct.CartId}");

            cart = checkoutClient.CartByCartIdGetAsync((Guid)cartProduct.CartId, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("Get Cart");
            System.Console.WriteLine($"Is Cart Null? {(cart == null ? "true" : "false")}");

            System.Console.ReadKey();
        }
    }
}