using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class Contact : Base
    {
        public string Icon  { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
