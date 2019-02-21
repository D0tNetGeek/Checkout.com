using Microsoft.EntityFrameworkCore;

namespace Checkout.EF
{
    using Checkout.Models;

    public class CheckoutContext : DbContext
    {
        public CheckoutContext() { }

        public CheckoutContext(DbContextOptions<CheckoutContext> options) : base(options) { }

        //Entity config
        public DbSet<CartEntity> Cart { get; set; }
        public DbSet<CountryEntity> Country { get; set; }
        public DbSet<ProductEntity> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductEntity>()
            .HasIndex(i => i.Code).IsUnique(true);

            //composite key
            builder.Entity<CartEntity>()
            .HasKey(k => new { k.CartId, k.ProductId });

            base.OnModelCreating(builder);
        }
    }
}