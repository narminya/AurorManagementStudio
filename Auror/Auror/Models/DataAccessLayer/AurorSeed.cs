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
                InitReservationStatus(db);
                InitRoomType(db);
                InitHotelCategories(db);
                InitHotel(db);
                InitHotelImages(db);
                //await db.SaveChangesAsync();
            }

            return app;
        }
        private static void InitHotelImages(AurorDataContext db)
        {
            if (!db.Images.Any())
            {
                db.Images.AddRange(
                    new HotelImage { Path = "hotel-2.jpg", HotelId = 7 },
                    new HotelImage { Path = "hotel-3.jpg", HotelId = 7 },
                    new HotelImage { Path = "hotel-4.jpg", HotelId = 7 },
                    new HotelImage { Path = "hotel-8.jpg", HotelId = 7 },
                    new HotelImage { Path = "hotel-2.jpg", HotelId = 4 },
                    new HotelImage { Path = "hotel-3.jpg", HotelId = 4 },
                    new HotelImage { Path = "hotel-4.jpg", HotelId = 4 },
                    new HotelImage { Path = "hotel-8.jpg", HotelId = 4 },
                    new HotelImage { Path = "hotel-2.jpg", HotelId = 5 },
                    new HotelImage { Path = "hotel-3.jpg", HotelId = 5 },
                    new HotelImage { Path = "hotel-4.jpg", HotelId = 5 },
                    new HotelImage { Path = "hotel-8.jpg", HotelId = 5 },
                    new HotelImage { Path = "hotel-2.jpg", HotelId = 6 },
                    new HotelImage { Path = "hotel-3.jpg", HotelId = 6 },
                    new HotelImage { Path = "hotel-4.jpg", HotelId = 6 },
                    new HotelImage { Path = "hotel-8.jpg", HotelId = 6 }
                    );
            }
            db.SaveChanges();
        }
        private static void InitHotel(AurorDataContext db)
        {
            if (!db.Hotel.Any())
            {
                db.Hotel.AddRange(
                    new Hotel
                    {
                        Name = "Aurora",
                        Location = "Street 5",
                        Rating = 49,
                        IsDeleted = false,
                        Phone = "+0(68)48214848",
                        HotelCategoryId = 17,
                        Description = " Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorum possimus aut eius fuga dolore ullam, " +
                        "velit laborum itaque numquam rem fugiat maxime modi sed voluptatibus a saepe aspernatur odio voluptas?"
                    },
                    new Hotel
                    {
                        Name = "Whoville",
                        Location = "Street 6",
                        Rating = 85,
                        IsDeleted = false,
                        Phone = "+0(68)47814848",
                        HotelCategoryId = 18,
                        Description = " Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorum possimus aut eius fuga dolore ullam, " +
                        "velit laborum itaque numquam rem fugiat maxime modi sed voluptatibus a saepe aspernatur odio voluptas?"
                    },
                    new Hotel
                    {
                        Name = "Gordon Hotel",
                        Location = "Street 12",
                        Rating = 79,
                        IsDeleted = false,
                        Phone = "+0(68)48212848",
                        HotelCategoryId = 19,
                        Description = " Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorum possimus aut eius fuga dolore ullam, " +
                        "velit laborum itaque numquam rem fugiat maxime modi sed voluptatibus a saepe aspernatur odio voluptas?"
                    },
                    new Hotel
                    {
                        Name = "Eleon",
                        Location = "Street 8",
                        Rating = 75,
                        IsDeleted = false,
                        Phone = "+0(68)96214848",
                        HotelCategoryId = 20,
                        Description = " Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorum possimus aut eius fuga dolore ullam, " +
                        "velit laborum itaque numquam rem fugiat maxime modi sed voluptatibus a saepe aspernatur odio voluptas?"
                    }
                    );
            }
            db.SaveChanges();
        }
        private static void InitHotelCategories(AurorDataContext db)
        {
            if (!db.HotelCategory.Any())
            {
                db.HotelCategory.AddRange(
                    new HotelCategory { Name = "Resort" },
                    new HotelCategory { Name = "All-suite" },
                    new HotelCategory { Name = "Conference" },
                    new HotelCategory { Name = "Boutique " }
                    );
            }
            db.SaveChanges();
        }
        private static void InitRoomType(AurorDataContext db)
        {
            if (!db.RoomType.Any())
            {
                db.RoomType.AddRange(
               new RoomType { Name = "Double" },
               new RoomType { Name = "Single" },
               new RoomType { Name = "King suite" },
               new RoomType { Name = "Prezident suite" },
               new RoomType { Name = "Twin" },
               new RoomType { Name = "Studio" }
               );
            }
            db.SaveChanges();
        }
        private static void InitReservationStatus(AurorDataContext db)
        {
            if (!db.ReservationStatus.Any())
            {
                db.ReservationStatus.AddRange(
                 new ReservationStatus { Status = "Active" },
                 new ReservationStatus { Status = "Suspended" },
                 new ReservationStatus { Status = "Closed" },
                 new ReservationStatus { Status = "Pelnaltization" });
            }
            db.SaveChanges();
        }
        private static void InitGender(AurorDataContext db)
        {
            if (!db.Gender.Any())
            {
                db.Gender.AddRange(
                    new Gender { Name = "Male" },
                    new Gender { Name = "Female" },
                    new Gender { Name = "Prefer not to say" });
            }
            db.SaveChanges();
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
            db.SaveChanges();

        }
    }
}
