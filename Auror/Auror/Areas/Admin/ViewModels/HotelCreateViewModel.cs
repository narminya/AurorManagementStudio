using Auror.Models.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.ViewModels
{
    public class HotelCreateViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? HotelCategoryId { get; set; }
        public string Description { get; set; }
        public IFormFile[] file { get; set; }
        public int fileSelectedIndex { get; set; }
        public List<HotelCategory> Category { get; set; }
        public List<Advantage> Advantage { get; set; }
        public int[] AdvantageId { get; set; }

    }
}
