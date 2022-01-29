using Auror.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.ViewModels
{
    public class RoomBookViewModel
    {
        [Required]
        public DateTime? CheckIn { get; set; }
        [Required]
        public DateTime? CheckOut { get; set; }
        public int HotelId { get; set; }
        [Required]
        public int Adults { get; set; }
        public int Kids { get; set; }

        public List<RoomType> RoomTypes { get; set; }
        public List<Room> Rooms { get; set; }

    }
}
