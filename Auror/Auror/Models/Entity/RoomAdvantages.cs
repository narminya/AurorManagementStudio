using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class RoomAdvantages : Base
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public bool Wifi { get; set; }
        public bool FreeBreakfast { get; set; }
        public bool Bathtub { get; set; }
        public bool Tv { get; set; }
        public bool AirConditioner { get; set; }


    }
}
