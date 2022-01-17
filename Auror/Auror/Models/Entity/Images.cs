using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class Images : Base
    {
        public string Path { get; set; }
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
