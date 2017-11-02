using DataAccess.Entities;
using DataAccess.Entities.ProductTypes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class MusicShopDbContext : IdentityDbContext<User>
    {
        //public MusicShopDbContext() { }

        public MusicShopDbContext(DbContextOptions<MusicShopDbContext> options) : base(options)
        {
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        //individual tables for specific product types
        public DbSet<DrumKit> DrumKit { get; set; }
        public DbSet<Guitar> Guitar { get; set; }
        public DbSet<Saxophone> Saxophone { get; set; }
        public DbSet<UserPayment> UserPayment { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }

    }
}