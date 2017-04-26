using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public static class DataAccessExtensions
    {

        public static void AddEntityFramework(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MusicShopDbContext>(options =>
                    options.UseSqlServer(connectionString));
        }
 

    }
}
