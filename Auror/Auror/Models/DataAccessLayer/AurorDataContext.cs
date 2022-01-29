using Auror.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.DataAccessLayer
{
    public class AurorDataContext : IdentityDbContext
    {
        public AurorDataContext(DbContextOptions<AurorDataContext> options)
        : base(options)
        {

        }
        public DbSet<Service> Services { get; set; }

        public DbSet<Comment> Comment { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelCategory> HotelCategory { get; set; }
        public DbSet<HotelImage> Images { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<ReservationStatus> ReservationStatus { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Navigation> Navigation { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<HotelAdvantages> HotelAdvantages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Message { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Ignore<Base>();
        }



    }
}
