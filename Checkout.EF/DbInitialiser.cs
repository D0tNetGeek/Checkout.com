using System.Linq;

namespace Checkout.EF
{
    using Models;

    /// <summary>
    /// Seeds the data for the context
    /// </summary>
    public static class DbInitialiser
    {
        private static CheckoutContext context;

        public static void Initialize(CheckoutContext ctx)
        {
            context = ctx;

            context.Database.EnsureCreated();

            Countries();
            Products();
        }

        //Add Countries
        private static void Countries()
        {
            if (!context.Country.Any())
            {
                context.Add(new CountryEntity { Id = 1, Name = "United Kingdom", IsoCode = "en-GB", Tax = 17.5M, IsDefault = true, IsActive = true });
                context.Add(new CountryEntity { Id = 2, Name = "Germany", IsoCode = "de-DE", Tax = 22.5M, IsActive = true });

                context.SaveChanges();
            }
        }

        //Add Products
        private static void Products()
        {
            if (!context.Product.Any())
            {
                context.Add(new ProductEntity { Id = 1, Name = "Adidas Swift Run", Code = "P001", NetPrice = 39.99M, ShortDescription = "Ready for action, the adidas Swift Run arrives in a streamlined profile for epic style and performance.", CountryId = 1, IsActive = true });
                context.Add(new ProductEntity { Id = 2, Name = "Puma Muse Chase", Code = "P002", NetPrice = 36.99M, ShortDescription = "This dynamic sneaker features a black fabric bootie upper with elastic foot straps and a supportive hot pink heel piece.", CountryId = 1, IsActive = true });
                context.Add(new ProductEntity { Id = 3, Name = "Converse", Code = "P003", NetPrice = 32.99M, ShortDescription = "The Converse kids' All Star Ox Glitter boasts a stunning man-made pink upper and durable vulcanised sole and toe cap to protect busy little feet.", CountryId = 1, IsActive = true });

                context.Add(new ProductEntity { Id = 4, Name = "Reebok", Code = "P004", NetPrice = 34.99M, ShortDescription = "The black leather upper creates a versatile silhouette while retro branding makes for an authentic feel. A 3.5cm platform finishes perfectly.", CountryId = 2, IsActive = true });
                context.Add(new ProductEntity { Id = 5, Name = "Nike Airforce 1", Code = "P005", NetPrice = 50.99M, ShortDescription = "The Air Force 1 features a padded ankle collar, with a chunky Air midsole and rubber outsole to finish.", CountryId = 2, IsActive = true });
                context.Add(new ProductEntity { Id = 6, Name = "Fila Disruptor", Code = "P006", NetPrice = 39.99M, ShortDescription = "This clean grey trainer features a nubuck layered upper with metallic rose gold accents while an exaggerated white outsole completes.", CountryId = 2, IsActive = true });

                context.SaveChanges();
            }
        }
    }
}