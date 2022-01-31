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
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auror.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AreaAdmin")]
    public class UserController : Controller
    {
        private readonly AurorDataContext _dt;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(AurorDataContext dt, RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, IAuthorizationService authorizationService)
        {
            _dt = dt;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _authorizationService = authorizationService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _userManager.Users.ToListAsync();
            var users = new List<UserViewModel>();
            foreach (var item in list)
            {

                users.Add(new UserViewModel()
                {
                    Id = item.Id,
                    Email = item.Email,
                    Username = item.UserName,
                    FullName = item.Name + " " + item.Surname,
                    Roles = (await _userManager.GetRolesAsync(item)).ToList(),

                });


            }


            return View(users);
        }

     
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _authorizationService.AuthorizeAsync(User, user, "UserHimselfPolicy");
            if (!result.Succeeded)
            {
                if (User.Identity.IsAuthenticated)
                {
                    return new ForbidResult();
                }
                else
                {
                    return new ChallengeResult();
                }
            }

            var roles = (await _userManager.GetRolesAsync(user)).ToList();
            var allRoles = await _roleManager.Roles.Select(o => new UserRolesViewModel { RoleId = o.Id, RoleName = o.Name }).ToListAsync();
            var claims =(await _userManager.GetClaimsAsync(user)).ToList();
            var usvm = new UserDetailViewModel()
            {
                Id = user.Id,
                UserRoles = roles.ToList(),
                FullName = user.Name + " " + user.Surname,
                Email = user.Email,
                Username = user.UserName,
                Phone = user.PhoneNumber,
                ProfilePhoto = user.ProfilePhoto,
                Roles = allRoles,
                UserClaims = claims
            };

            return View(usvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AddRoles(string role, string id)
        {
            var roleName = await _dt.Roles.FindAsync(role);
            if (roleName == null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(user, roleName.Name);
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Detail), new { id = id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveRoles(string role, string id)
        {
            var roleName = await _roleManager.Roles.Where(c=>c.Name==role).FirstOrDefaultAsync();
            if (roleName==null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.RemoveFromRoleAsync(user, roleName.Name);
            return RedirectToAction(nameof(Detail), new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddClaim(Claim claim, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.RemoveClaimAsync(user, claim);
            return RedirectToAction(nameof(Detail), new { id = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveClaim(string type, string claimValue, string id)
        {
            Claim claim = new Claim(type, claimValue);
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddClaimAsync(user, claim);
            return RedirectToAction(nameof(Detail), new { id = id });
        }
    }
}
