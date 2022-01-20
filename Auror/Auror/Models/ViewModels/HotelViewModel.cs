using Auror.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.ViewModels
{
    public class HotelViewModel
    {
        public List<HotelCategory> Categories { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
