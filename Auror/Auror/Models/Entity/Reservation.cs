using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class Reservation : Base
    {
        public Reservation()
        {
            ActiveTill = CheckIn.AddDays(1);
        }

        public int? GuestId { get; set; }
        public Guest Guest { get; set; }
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime ActiveTill { get; set; } 
        public decimal TotalPrice { get; set; } = 0;
        public int PeopleCount { get; set; }
        public int? ReservationStatusId { get; set; } = 1;
        public ReservationStatus ReservationStatus { get; set; }
        public ICollection<ReservationRooms> Rooms { get; set; }
    }
}
