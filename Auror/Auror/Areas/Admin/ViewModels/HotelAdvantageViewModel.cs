using Auror.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.ViewModels
{
    public class HotelAdvantageViewModel
    {
        public List<Hotel> Hotel { get; set; }
        public List<Advantage> Advantage { get; set; }
    }
}
