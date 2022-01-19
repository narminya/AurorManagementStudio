using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.ViewComponents
{
    public class UserViewComponent : ViewComponent
    {
        private readonly AurorDataContext _dt;
        private readonly UserManager<User> _userManager;
        public UserViewComponent(AurorDataContext dt, UserManager<User> userManager)
        {
            _dt = dt;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(user);
        }

    }
}
