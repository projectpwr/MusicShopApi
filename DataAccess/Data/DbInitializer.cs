using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Data
{
    public static class DbInitializer
        {
            public static void Initialize(MusicShopDbContext context, UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager)
            {                
                //check for users
                if ( context.Users.Any() )
                {
                    context.Database.Migrate();
                    return; // DB has been seeded
                };

                //otherwise remove everything and seed from scratch
                context.Database.EnsureDeleted();
                context.Database.Migrate();

      
                UserEntity admin = new UserEntity { UserName = "admin@musicshop.com", Email = "admin@musicshop.com" };
                UserEntity basic = new UserEntity { UserName = "basic@musicshop.com", Email = "basic@musicshop.com" };
                var adminResult = userManager.CreateAsync(admin, "Password9!").Result;
                var userResult = userManager.CreateAsync(basic, "Password9!").Result;
                
                IdentityRole adminRole = new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" };
                var roleResult = roleManager.CreateAsync(adminRole).Result;

                UserEntity adminUser = userManager.Users.Where(x => x.Email == "admin@musicshop.com").First();
                var adminRoleUserResult = userManager.AddToRoleAsync(adminUser, "Admin").Result;


        }
       

    }
}
