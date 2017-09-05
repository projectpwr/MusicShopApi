using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Data
{
    public static class DbInitializer
        {
            public static void Initialize(MusicShopDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
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

      
                User admin = new User { UserName = "admin@musicshop.com", Email = "admin@musicshop.com" };
                User basic = new User { UserName = "basic@musicshop.com", Email = "basic@musicshop.com" };
                var adminResult = userManager.CreateAsync(admin, "Password9!").Result;
                var userResult = userManager.CreateAsync(basic, "Password9!").Result;
                
                IdentityRole adminRole = new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" };
                var roleResult = roleManager.CreateAsync(adminRole).Result;
                IdentityRole adminRole2 = new IdentityRole { Name = "secondrole", NormalizedName = "SECONDROLE" };
                roleResult = roleManager.CreateAsync(adminRole2).Result;

                User adminUser = userManager.Users.Where(x => x.Email == "admin@musicshop.com").First();
                var t = userManager.AddToRoleAsync(adminUser, "Admin").Result;
                var tt = userManager.AddToRoleAsync(adminUser, "secondrole").Result;

        }
       

    }
}
