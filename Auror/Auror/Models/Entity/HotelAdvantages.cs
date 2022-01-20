using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class HotelAdvantages : Base
    {
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int? AdvantageId { get; set; }
        public Advantage Advantage { get; set; }

    }
}
