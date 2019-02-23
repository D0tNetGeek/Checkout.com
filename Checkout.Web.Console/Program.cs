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

            //Get product by Id
            var result = checkoutClient.CartByCartIdGetAsync(Guid.NewGuid(), "1").GetAwaiter().GetResult();

            System.Console.WriteLine("Result : "+String.Join(", ", result));

            System.Console.ReadKey();
        }
    }
}