using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class Navigation : Base
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public string Controller { get; set; }
    }
}
