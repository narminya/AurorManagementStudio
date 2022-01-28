using Auror.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.ViewModels
{
    public class RoomBookViewModel
    {
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int HotelId { get; set; }
        public int Adults { get; set; }
        public int Kids { get; set; }

        public List<ReservationRooms> Rooms { get; set; }
        public List<RoomType> RoomTypes { get; set; }
    }
}
