using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.Entity
{
    public class Comment : Base
    {
        public string Content { get; set; }
        public bool IsItAnswer { get; set; }
        public Comment ParentComment { get; set; }
        public ICollection<Comment> Children { get; set; }

    }
}
