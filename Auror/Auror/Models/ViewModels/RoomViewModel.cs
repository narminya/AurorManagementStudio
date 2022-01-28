using Auror.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.ViewModels
{
    public class RoomViewModel
    {
        public List<Room> Rooms { get; set; }
        public List<RoomType> RoomTypes { get; set; }
    }
}
