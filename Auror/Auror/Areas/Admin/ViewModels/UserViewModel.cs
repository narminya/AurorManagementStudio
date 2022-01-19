using Auror.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.ViewModels
{
    public class UserViewModel
    {
        public List<User> SuperAdmins { get; set; }
        public List<User> Admins { get; set; }
        public List<User> Hotel{ get; set; }
        public List<User> Users { get; set; }
    }
}
