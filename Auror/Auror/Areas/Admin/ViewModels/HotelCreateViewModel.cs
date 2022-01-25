using Auror.Models.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.ViewModels
{
    public class HotelCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required, DataType(DataType.EmailAddress)]
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
