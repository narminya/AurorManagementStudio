using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class HotelComments : Base
    {
        public int? CommentId { get; set; }
        public Comment Comment { get; set; }
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
       
    }
}
