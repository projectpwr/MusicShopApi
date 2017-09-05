using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Services.Models;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }



        public IConfigurationRoot Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = MusicShopDbContextFactory.GetDefaultMusicShopDbConnection();
            var dbContextFactory = new MusicShopDbContextFactory();
            var dbContext = dbContextFactory.Create(new DbContextFactoryOptions());


            services.AddCors();

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<MusicShopDbContext>()
                    .AddDefaultTokenProviders();

            // Add in EF
            services.AddEntityFramework( connectionString );



            // Add framework services.
            services.AddMvc();

            services.Configure<AppConfiguration>(Configuration.GetSection("AppConfiguration"));
            //intercept any unauthorized requests that come inot the api and rather than redirecting to account/login 
            //(since were using identity) return a 401 unauthorized header
            services.Configure<IdentityOptions>(config =>
                {
                    config.Cookies.ApplicationCookie.Events =
                        new CookieAuthenticationEvents
                        {
                            //default action when we are not logged in is to redirect to login, we're adjusting the behaviour of this here...
                            OnRedirectToLogin = ctx =>
                            {
                                //if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                                //{
                                    ctx.Response.StatusCode = 401;
                                    return Task.FromResult<object>(null);
                                //}

                                //ctx.Response.Redirect(ctx.RedirectUri);
                                //return Task.FromResult<object>(null);
                            }
                        };
                });


        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, MusicShopDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Shows UseCors with CorsPolicyBuilder. - allow react app to access this api. react app default port is 3000.
            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                );
                
            app.UseIdentity();


            //TODO: setup refresh tokens so expired bearer tokens can be refreshed automatically
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppConfiguration:Key").Value)),
                    ValidAudience = Configuration.GetSection("AppConfiguration:SiteUrl").Value,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = Configuration.GetSection("AppConfiguration:SiteUrl").Value
                    
                }
                
            });



            app.UseMvc();

            DbInitializer.Initialize(context, userManager, roleManager);
        }
    }
}
