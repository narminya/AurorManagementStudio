using Auror.Models.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.ViewModels
{
    public class RoomCreateViewModel
    {
        public string Number { get; set; }
        public bool IsAvailable { get; set; }
        public decimal CurrentPrice { get; set; }
        [Range(1, 4, ErrorMessage = "Only positive number allowed")]
        public int PeopleCount { get; set; }
        [Range(25, 100, ErrorMessage = "Only positive number allowed")]
        public int RoomSquare { get; set; }
        [Range(1, 4, ErrorMessage = "Only positive number allowed")]
        public int BedCount { get; set; }
        public int? HotelId { get; set; }
        public int? RoomTypeId { get; set; }
        public IFormFile[] file { get; set; }
        public int fileSelectedIndex { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<RoomType> RoomType { get; set; }

    }
}
