using Auror.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.ViewModels
{
    public class AllHotelsShowViewModel
    {
 
        public List<Hotel> Hotels { get; set; }
        public List<HotelCategory> Categories { get; set; }
    }
}
