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
                InitNavigation(db);
                InitAdvantages(db);
                InitHotelAdvantages(db);
                InitRooms(db);
                InitRoomImages(db);
                //  InitComments(db);
                InitServices(db);
                InitContact(db);
               InitReservation(db);
                InitGuest(db);
                //await db.SaveChangesAsync();
            }

            return app;
        }

        private static void InitContact(AurorDataContext db)
        {
            if (!db.Contacts.Any())
            {
                db.Contacts.AddRange(
                    new Contact { Content = "Bakı,Azərbaycan", Name = "Ünvan", Icon = "9.svg" },
                    new Contact { Content = "+99455 555-55-55", Name = "Telefon", Icon = "10.svg" },
                    new Contact { Content = "Email", Name = "inbox@mail.com", Icon = "11.svg" }

                    );
            }

            db.SaveChanges();
        }

        private static void InitServices(AurorDataContext db)
        {
            if (!db.Services.Any())
            {
                db.Services.AddRange(
                       new Service { Name = "Lounge Bar", ImagePath = "1.jpg", Description = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Delectus, rerum?" },
                       new Service { Name = "Hovuz", ImagePath = "2.jpg", Description = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Delectus, rerum?" },
                       new Service { Name = "Restorant", ImagePath = "3.jpg", Description = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Delectus, rerum?" },
                       new Service { Name = "Oyun Zalı", ImagePath = "4.jpg", Description = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Delectus, rerum?" },
                       new Service { Name = "Spa Salonu", ImagePath = "5.jpg", Description = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Delectus, rerum?" },
                       new Service { Name = "İdman Zalı", ImagePath = "6.jpg", Description = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Delectus, rerum?" }
                    );
                db.SaveChanges();
            }
        }

        private static void InitComments(AurorDataContext db)
        {
            if (!db.Comment.Any())
            {
                db.Comment.AddRange(
                    new Comment
                    {
                        Content = " Lorem ipsum dolor sit amet consectetur,adipisicing elit.Aliquid doloribus" +
                        "illoreiciendis officiis.Assumenda aspernatur ut autem distinctio eos nihil error quaerat quam.",
                        HotelId = 1,
                        Rating = 4,
                        UserId = "1e64102e-ee2e-4e6f-89c6-346d4d9db801"
                    },
                    new Comment
                    {
                        Content = " Lorem ipsum dolor sit amet consectetur,adipisicing elit.Aliquid doloribus" +
                        "illoreiciendis officiis.Assumenda aspernatur ut autem distinctio eos nihil error quaerat quam.",
                        HotelId = 2,
                        Rating = 3,
                        UserId = "5f91fc89-ae62-4c9f-a940-cd027165fb5b"
                    },
                    new Comment
                    {
                        Content = " Lorem ipsum dolor sit amet consectetur,adipisicing elit.Aliquid doloribus" +
                        "illoreiciendis officiis.Assumenda aspernatur ut autem distinctio eos nihil error quaerat quam.",
                        HotelId = 2,
                        Rating = 4,
                        UserId = "b68a4a79-ed27-4d23-b934-87e7e3e9a2e1"
                    }
                    );
                db.SaveChanges();
            }
        }

        private static void InitRoomImages(AurorDataContext db)
        {
            if (!db.RoomImages.Any())
            {
                db.RoomImages.AddRange(
                 new RoomImage { IsMain = true, Path = "1.jpg", RoomId = 1 },
                 new RoomImage { IsMain = true, Path = "2.jpg", RoomId = 2 },
                 new RoomImage { IsMain = true, Path = "3.jpg", RoomId = 3 },
                 new RoomImage { IsMain = true, Path = "4.jpg", RoomId = 4 },
                 new RoomImage { IsMain = true, Path = "1.jpg", RoomId = 5 },
                 new RoomImage { IsMain = true, Path = "2.jpg", RoomId = 6 },
                 new RoomImage { IsMain = true, Path = "1.jpg", RoomId = 7 },
                 new RoomImage { IsMain = true, Path = "2.jpg", RoomId = 8 },
                 new RoomImage { IsMain = true, Path = "3.jpg", RoomId = 9 },
                 new RoomImage { IsMain = true, Path = "1.jpg", RoomId = 10 },
                 new RoomImage { IsMain = true, Path = "2.jpg", RoomId = 11 },
                 new RoomImage { IsMain = true, Path = "4.jpg", RoomId = 12 },
                 new RoomImage { IsMain = true, Path = "1.jpg", RoomId = 14 },
                 new RoomImage { IsMain = true, Path = "2.jpg", RoomId = 15 },
                 new RoomImage { IsMain = true, Path = "3.jpg", RoomId = 16 },
                 new RoomImage { IsMain = true, Path = "4.jpg", RoomId = 17 },
                 new RoomImage { IsMain = true, Path = "1.jpg", RoomId = 18 },
                 new RoomImage { IsMain = true, Path = "4.jpg", RoomId = 19 },
                 new RoomImage { IsMain = true, Path = "1.jpg", RoomId = 20 },
                 new RoomImage { IsMain = true, Path = "2.jpg", RoomId = 21 },
                 new RoomImage { IsMain = true, Path = "3.jpg", RoomId = 22 },
                 new RoomImage { IsMain = true, Path = "4.jpg", RoomId = 23 }

                 );
            }
            db.SaveChanges();

        }

        private static void InitGuest(AurorDataContext db)
        {
            if (!db.Guest.Any())
            {
                db.Guest.AddRange(
                    new Guest { Name = "Brad", Surname = "Pitt", Email = "bradpitt@gmail.com", GenderId = 2, UserId = "1e64102e-ee2e-4e6f-89c6-346d4d9db801" },
                    new Guest { Name = "Chris", Surname = "Hemsworth", Email = "chrish@gmail.com", GenderId = 2, UserId = "5f91fc89-ae62-4c9f-a940-cd027165fb5b" },
                    new Guest { Name = "Tom", Surname = "Hiddleston", Email = "tomh@gmail.com", GenderId = 2, UserId = "b68a4a79-ed27-4d23-b934-87e7e3e9a2e1" }
                    );
                db.SaveChanges();
            }
        }

        private static void InitReservation(AurorDataContext db)
        {
            if (!db.Reservation.Any())
            {
                db.AddRange(new Reservation { CheckIn = new DateTime(2022,02,01,12,00,00), CheckOut = new DateTime(2022, 02, 05, 12, 00, 00), PeopleCount = 1,RoomId = 2, GuestId = 1, ReservationStatusId = 1, TotalPrice = 0, HotelId = 1 });
            }
            db.SaveChanges();
        }
        private static void InitRooms(AurorDataContext db)
        {
            if (!db.Room.Any())
            {
                db.Room.AddRange(
                    new Room { Name = "D100", RoomTypeId = 4, IsAvailable = true, PeopleCount = 2, BedCount = 2, CurrentPrice = 250, RoomSquare = 50, HotelId = 1 },
                    new Room { Name = "D135", RoomTypeId = 4, IsAvailable = true, PeopleCount = 2, BedCount = 2, CurrentPrice = 250, RoomSquare = 50, HotelId = 2 },
                    new Room { Name = "P420", RoomTypeId = 1, IsAvailable = true, PeopleCount = 4, BedCount = 4, CurrentPrice = 700, RoomSquare = 90, HotelId = 2 },
                    new Room { Name = "P630", RoomTypeId = 1, IsAvailable = true, PeopleCount = 4, BedCount = 4, CurrentPrice = 700, RoomSquare = 95, HotelId = 1 },
                    new Room { Name = "S110", RoomTypeId = 3, IsAvailable = true, PeopleCount = 1, BedCount = 1, CurrentPrice = 200, RoomSquare = 40, HotelId = 4 },
                    new Room { Name = "S205", RoomTypeId = 3, IsAvailable = true, PeopleCount = 1, BedCount = 1, CurrentPrice = 200, RoomSquare = 40, HotelId = 4 },
                    new Room { Name = "T121", RoomTypeId = 5, IsAvailable = true, PeopleCount = 2, BedCount = 2, CurrentPrice = 200, RoomSquare = 35, HotelId = 1 },
                    new Room { Name = "D108", RoomTypeId = 4, IsAvailable = true, PeopleCount = 2, BedCount = 2, CurrentPrice = 250, RoomSquare = 50, HotelId = 1 },
                    new Room { Name = "D137", RoomTypeId = 4, IsAvailable = true, PeopleCount = 2, BedCount = 2, CurrentPrice = 250, RoomSquare = 50, HotelId = 3 },
                    new Room { Name = "P425", RoomTypeId = 1, IsAvailable = true, PeopleCount = 4, BedCount = 4, CurrentPrice = 700, RoomSquare = 90, HotelId = 1 },
                    new Room { Name = "P662", RoomTypeId = 1, IsAvailable = true, PeopleCount = 4, BedCount = 4, CurrentPrice = 700, RoomSquare = 95, HotelId = 1 },
                    new Room { Name = "S203", RoomTypeId = 3, IsAvailable = true, PeopleCount = 1, BedCount = 1, CurrentPrice = 200, RoomSquare = 40, HotelId = 3 },
                    new Room { Name = "S301", RoomTypeId = 3, IsAvailable = true, PeopleCount = 1, BedCount = 1, CurrentPrice = 200, RoomSquare = 40, HotelId = 2 },
                    new Room { Name = "T111", RoomTypeId = 5, IsAvailable = true, PeopleCount = 2, BedCount = 2, CurrentPrice = 200, RoomSquare = 35, HotelId = 3 },
                    new Room { Name = "S295", RoomTypeId = 3, IsAvailable = true, PeopleCount = 1, BedCount = 1, CurrentPrice = 200, RoomSquare = 40, HotelId = 4 },
                    new Room { Name = "T127", RoomTypeId = 5, IsAvailable = true, PeopleCount = 2, BedCount = 2, CurrentPrice = 200, RoomSquare = 35, HotelId = 1 },
                    new Room { Name = "D148", RoomTypeId = 4, IsAvailable = true, PeopleCount = 2, BedCount = 2, CurrentPrice = 250, RoomSquare = 50, HotelId = 1 },
                    new Room { Name = "D137", RoomTypeId = 4, IsAvailable = true, PeopleCount = 2, BedCount = 2, CurrentPrice = 250, RoomSquare = 50, HotelId = 4 },
                    new Room { Name = "P425", RoomTypeId = 1, IsAvailable = true, PeopleCount = 4, BedCount = 4, CurrentPrice = 700, RoomSquare = 90, HotelId = 4 },
                    new Room { Name = "P674", RoomTypeId = 1, IsAvailable = true, PeopleCount = 4, BedCount = 4, CurrentPrice = 700, RoomSquare = 95, HotelId = 2 },
                    new Room { Name = "S223", RoomTypeId = 3, IsAvailable = true, PeopleCount = 1, BedCount = 1, CurrentPrice = 200, RoomSquare = 40, HotelId = 1 },
                    new Room { Name = "S361", RoomTypeId = 3, IsAvailable = true, PeopleCount = 1, BedCount = 1, CurrentPrice = 200, RoomSquare = 40, HotelId = 3 },
                    new Room { Name = "T171", RoomTypeId = 5, IsAvailable = true, PeopleCount = 2, BedCount = 2, CurrentPrice = 200, RoomSquare = 35, HotelId = 1 }
                    );
                db.SaveChanges();

            }
        }
        private static void InitAdvantages(AurorDataContext db)
        {
            if (!db.Advantages.Any())
            {
                db.Advantages.AddRange(
                    new Advantage { Name = "All Inclusive", Icon = "2.svg" },
                    new Advantage { Name = "Airport Transfer", Icon = "1.svg" },
                    new Advantage { Name = "Air Conditioner", Icon = "3.svg" },
                    new Advantage { Name = "Security", Icon = "4.svg" },
                    new Advantage { Name = "Pool", Icon = "5.svg" },
                    new Advantage { Name = "Wifi", Icon = "6.svg" },
                    new Advantage { Name = "Smart tv", Icon = "7.svg" },
                    new Advantage { Name = "Laundry Service", Icon = "8.svg" }

                    );
                db.SaveChanges();

            }

        }
        private static void InitHotelAdvantages(AurorDataContext db)
        {
            if (!db.HotelAdvantages.Any())
            {
                db.HotelAdvantages.AddRange(
                    new HotelAdvantages { HotelId = 1, AdvantageId = 1 },
                    new HotelAdvantages { HotelId = 1, AdvantageId = 2 },
                    new HotelAdvantages { HotelId = 1, AdvantageId = 3 },
                    new HotelAdvantages { HotelId = 1, AdvantageId = 4 },
                    new HotelAdvantages { HotelId = 1, AdvantageId = 5 },
                    new HotelAdvantages { HotelId = 1, AdvantageId = 6 },
                    new HotelAdvantages { HotelId = 1, AdvantageId = 7 },
                    new HotelAdvantages { HotelId = 1, AdvantageId = 8 },
                    new HotelAdvantages { HotelId = 2, AdvantageId = 1 },
                    new HotelAdvantages { HotelId = 2, AdvantageId = 3 },
                    new HotelAdvantages { HotelId = 2, AdvantageId = 4 },
                    new HotelAdvantages { HotelId = 2, AdvantageId = 6 },
                    new HotelAdvantages { HotelId = 2, AdvantageId = 8 },
                    new HotelAdvantages { HotelId = 3, AdvantageId = 1 },
                    new HotelAdvantages { HotelId = 3, AdvantageId = 3 },
                    new HotelAdvantages { HotelId = 3, AdvantageId = 7 },
                    new HotelAdvantages { HotelId = 3, AdvantageId = 6 },
                    new HotelAdvantages { HotelId = 3, AdvantageId = 8 },
                    new HotelAdvantages { HotelId = 4, AdvantageId = 8 },
                    new HotelAdvantages { HotelId = 4, AdvantageId = 2 },
                    new HotelAdvantages { HotelId = 4, AdvantageId = 6 },
                    new HotelAdvantages { HotelId = 4, AdvantageId = 5 }

                    );
                db.SaveChanges();

            }

        }
        private static void InitNavigation(AurorDataContext db)
        {
            if (!db.Navigation.Any())
            {
                db.Navigation.AddRange(
                    new Navigation { Name = "Ana Səhifə", Order = 1, Controller = "Home" },
                    new Navigation { Name = "Haqqımızda", Order = 2, Controller = "About" },
                    new Navigation { Name = "Hotellər", Order = 3, Controller = "Hotel" },
                    new Navigation { Name = "Xidmətlərimiz", Order = 5, Controller = "Service" },
                    new Navigation { Name = "Əlaqə", Order = 6, Controller = "Contact" }
                    );
            }
            db.SaveChanges();
        }
        private static void InitHotelImages(AurorDataContext db)
        {
            if (!db.Images.Any())
            {
                db.Images.AddRange(
                    new HotelImage { Path = "hotel-2.jpg", HotelId = 1 },
                    new HotelImage { Path = "hotel-3.jpg", IsMain = true, HotelId = 1 },
                    new HotelImage { Path = "hotel-4.jpg", HotelId = 1 },
                    new HotelImage { Path = "hotel-8.jpg", HotelId = 1 },
                    new HotelImage { Path = "hotel-2.jpg", IsMain = true, HotelId = 4 },
                    new HotelImage { Path = "hotel-3.jpg", HotelId = 4 },
                    new HotelImage { Path = "hotel-4.jpg", HotelId = 4 },
                    new HotelImage { Path = "hotel-8.jpg", HotelId = 4 },
                    new HotelImage { Path = "hotel-2.jpg", HotelId = 3 },
                    new HotelImage { Path = "hotel-3.jpg", HotelId = 3 },
                    new HotelImage { Path = "hotel-4.jpg", IsMain = true, HotelId = 3 },
                    new HotelImage { Path = "hotel-8.jpg", HotelId = 3 },
                    new HotelImage { Path = "hotel-2.jpg", HotelId = 2 },
                    new HotelImage { Path = "hotel-3.jpg", HotelId = 2 },
                    new HotelImage { Path = "hotel-4.jpg", HotelId = 2 },
                    new HotelImage { Path = "hotel-8.jpg", IsMain = true, HotelId = 2 }
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
                        HotelCategoryId = 1,
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
                        HotelCategoryId = 2,
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
                        HotelCategoryId = 3,
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
                        HotelCategoryId = 4,
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
