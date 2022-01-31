using Auror.Constants;
using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Auror.Security;
using Microsoft.AspNetCore.Authorization;
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
                options.AddPolicy("NonUser&Hotel", policyBuilder => policyBuilder.RequireAssertion(
                       context => context.User.IsInRole(RoleConstants.SuperAdmin) ||
                                  context.User.IsInRole(RoleConstants.Admin) || context.User.IsInRole(RoleConstants.Hotel)));


                options.AddPolicy("HotelPermissionPolicy", policy =>
                   policy.AddRequirements(new HotelRequirement()));

                options.AddPolicy("UserHimselfPolicy", policy =>
                   policy.AddRequirements(new SameUserRequirement()));

                options.AddPolicy("AreaAdmin", policyBuilder => policyBuilder.RequireAssertion(
                    context => context.User.IsInRole("SuperAdmin")));

                options.AddPolicy("Super&Admin", policyBuilder => policyBuilder.RequireAssertion(
                  context => context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin")));
            });

            services.AddDbContext<AurorDataContext>(options =>
            {
                options.UseSqlServer(_conf.GetConnectionString("DefaultConnection"));
            });

            services.AddSingleton<IAuthorizationHandler, HotelPermissionHandler>();
            services.AddSingleton<IAuthorizationHandler, SameUserPermissionHandler>();

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
