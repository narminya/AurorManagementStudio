using Auror.Constants;
using Auror.Models.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.DataAccessLayer
{
    public static class AurorSeed
    {
        public async static Task<IApplicationBuilder> Seed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AurorDataContext>();
                var role = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                db.Database.Migrate();

               await InitRoles(db, role);
                InitGender(db);

                await db.SaveChangesAsync();
            }

            return app;
        }

        private static void InitGender(AurorDataContext db)
        {
            if (!db.Gender.Any())
            {
                db.Gender.AddRange(
                    new Gender { Name = "Male" },
                    new Gender { Name = "Female" },
                    new Gender { Name = "Prefer not to say" }
                    );
            }
        }

        private static async Task InitRoles(AurorDataContext db, RoleManager<IdentityRole> role)
        {
            if (!db.Roles.Any())
            {
                await role.CreateAsync(new IdentityRole { Name = RoleConstants.Admin });
                await role.CreateAsync(new IdentityRole { Name = RoleConstants.User });
                await role.CreateAsync(new IdentityRole { Name = RoleConstants.SuperAdmin });
                await role.CreateAsync(new IdentityRole { Name = RoleConstants.Hotel });

            }
          
        }
    }
}
