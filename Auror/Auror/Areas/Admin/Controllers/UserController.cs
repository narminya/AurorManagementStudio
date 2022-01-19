using Auror.Areas.Admin.ViewModels;
using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AreaAdmin")]
    public class UserController : Controller
    {
        private readonly AurorDataContext _dt;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(AurorDataContext dt, SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dt = dt;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var uvm = new UserViewModel()
            {
                //Users = _dt.Users.Where(c=>c.)
            };

            return View();
        }
    }
}
