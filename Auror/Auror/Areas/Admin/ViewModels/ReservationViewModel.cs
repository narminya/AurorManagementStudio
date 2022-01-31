using Auror.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.ViewModels
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }
        public string Hotel { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime In { get; set; }
        public DateTime Out { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
