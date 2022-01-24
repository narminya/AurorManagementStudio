using Auror.Constants;
using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Auror
{
    public class Startup
    {
        private readonly IConfiguration _conf;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration conf, IWebHostEnvironment env)
        {
            _conf = conf;
            _env = env;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AurorDataContext>().AddDefaultTokenProviders();

            services.AddControllersWithViews()
              .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling
              = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAuthorization(options =>
            {
                //    options.AddPolicy("Hotel", policy => policy.RequireRole("Hotel").RequireClaim("EditHotels", "true")
                //    .RequireClaim("DeleteHotels", "true"));

                //options.AddPolicy("Admin&Moderator", policy => policy.RequireClaim("Admin").RequireClaim("Moderator"));

                //options.AddPolicy("User", policy => policy.RequireRole("User"));

                //options.AddPolicy("Hotels", policyBuilder => policyBuilder.RequireAssertion(
                //    context => context.User.IsInRole("SuperAdmin") || context.User.HasClaim("Edit&DeleteHotel","true")
                //    || context.User.IsInRole("Hotel")
                //    ));

                options.AddPolicy("AreaAdmin", policyBuilder => policyBuilder.RequireAssertion(
                    context => context.User.IsInRole("SuperAdmin") ||
                               context.User.IsInRole("Hotel") && context.User.HasClaim("Admin", "true")
                    ));
            });


            services.AddDbContext<AurorDataContext>(options =>
            {
                options.UseSqlServer(_conf.GetConnectionString("DefaultConnection"));
            });

            FileConstant.ImagePath = Path.Combine(_env.WebRootPath, "img");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
           await app.Seed();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                 );
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
