using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class RoomImage : Base
    {
        public string Path { get; set; }
        public int? RoomId { get; set; }
        public Room Room { get; set; }
    }
}
