using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class Reservation : Base
    {
        public int? GuestId { get; set; }
        public Guest Guest { get; set; }
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
        public int PeopleCount { get; set; }
        public int? ReservationStatusId { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public ICollection<ReservationRooms> Rooms { get; set; }
    }
}
