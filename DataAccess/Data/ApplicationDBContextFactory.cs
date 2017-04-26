using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Data
{
    public class MusicShopDbContextFactory : IDbContextFactory<MusicShopDbContext>
    {
        public MusicShopDbContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MusicShopDbContext>();
            var defaultConnection =
                optionsBuilder.UseSqlServer( GetDefaultMusicShopDbConnection() );
            return new MusicShopDbContext(optionsBuilder.Options);
        }

        public static string GetDefaultMusicShopDbConnection()
        {
            return "Server=(localdb)\\MSSQLLocalDB;Database=MusicShopDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        }


    }

}
