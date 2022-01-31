using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AreaAdmin")]
    public class DashboardController : Controller
    {
        private readonly AurorDataContext _dt;
        private readonly UserManager<User> _userManager;
        public DashboardController(AurorDataContext dt, UserManager<User> userManager)
        {
            _dt = dt;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            return View();
        }
    }
}
