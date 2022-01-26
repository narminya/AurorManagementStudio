using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class Message : Base
    {
        public string Content { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool IsAnswered { get; set; }
        public DateTime AnsweredDate { get; set; }
        public string Answer { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }
    }
}
