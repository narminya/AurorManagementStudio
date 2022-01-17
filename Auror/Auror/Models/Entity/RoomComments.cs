using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class RoomComments : Base
    {
        public int? CommentId { get; set; }
        public Comment Comment { get; set; }
        public int? RoomId { get; set; }
        public Room Room { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
       
    }
}
