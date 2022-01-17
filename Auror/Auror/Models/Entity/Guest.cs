using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class Guest : Base
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? GenderId { get; set; }
        public Gender Gender { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
