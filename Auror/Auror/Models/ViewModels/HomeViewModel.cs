using Auror.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Room> Rooms { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
