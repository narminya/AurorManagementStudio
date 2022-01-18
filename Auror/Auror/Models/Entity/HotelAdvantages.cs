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
        public bool Restaurant { get; set; }
        public bool Gym { get; set; }
        public bool Pool { get; set; }
        public bool FreeCancel { get; set; }
        public bool Parking { get; set; }
        public bool Security { get; set; }
        public bool Laundry { get; set; }
        public bool AllInclusive { get; set; }
        public bool AirportTransfer { get; set; }
    }
}
