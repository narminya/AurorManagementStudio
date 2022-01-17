using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class Hotel : Base
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        //Category
        public int? HotelCategoryId { get; set; }
        public HotelCategory HotelCategory { get; set; }
        public string Description { get; set; }
        public string DefaultImage { get; set; }
        public ICollection<Images> Images { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<HotelAdvantages> Advantages { get; set; }
        public ICollection<HotelTag> Tags { get; set; }



    }
}
