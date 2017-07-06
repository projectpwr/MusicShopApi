﻿using DataAccess.Entities;
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


        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}