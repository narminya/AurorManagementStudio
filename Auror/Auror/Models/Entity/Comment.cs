using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class Comment : Base
    {
        public string Content { get; set; }
        public int Rating { get; set; }
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }

    }
}
