using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.ViewModels
{
    public class UserDetailViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string ProfilePhoto { get; set; }
        public string Phone { get; set; }

        public List<string> UserRoles { get; set; }
        public List<Claim> UserClaims { get; set; }
        public List<UserRolesViewModel> Roles { get; set; }
    }
}
