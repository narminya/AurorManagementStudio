using Auror.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.ViewModels
{
    public class HotelDetailViewModel
    {

        public Hotel Hotel { get; set; }
        public List<Advantage> Advantages { get; set; }
    }
}
