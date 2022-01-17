using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class HotelTag : Base
    {
        public int? TagsId { get; set; }
        public Tags Tags { get; set; }
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
