using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.ViewModels
{
    public class ReservationViewModel
    {
        public int HotelId { get; set; }
        public int GuestId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int PeopleCount { get; set; }
        public int ReservationStatusId { get; set; }
        public int RoomId { get; set; }
    }
}
