using Auror.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.ViewModels
{
    public class HotelUserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<Hotel> hotels  { get; set; }
        [Required, Display(Name = "Choose hotel")]
        public int Hotel { get; set; }
    }
}
