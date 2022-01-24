using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class HotelImage : Base
    {
        public string Path { get; set; }
        public bool IsMain { get; set; }
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
