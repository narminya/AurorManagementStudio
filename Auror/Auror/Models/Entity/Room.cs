using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class Room : Base
    {
        public string Name { get; set; }
        public int? RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public bool IsAvailable { get; set; }
        public decimal CurrentPrice { get; set; }
        public int PeopleCount { get; set; }
        public int RoomSquare { get; set; }
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public ICollection<RoomAdvantages> Advantages { get; set; }
        public ICollection<RoomComments> Comments { get; set; }

    }
}
