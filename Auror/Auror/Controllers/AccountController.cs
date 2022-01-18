using Auror.Constants;
using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Auror.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace Auror.Controllers
{
    public class AccountController : Controller
    {
        private readonly AurorDataContext _dt;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(AurorDataContext dt, SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dt = dt;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(lvm.Email);
            if (user == null)
            {
                ModelState.AddModelError(nameof(lvm.Email), "User is not found");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, lvm.Password, lvm.KeepMeSigned, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid Credentials");
                return View();
            }

            if ((await _userManager.IsInRoleAsync(user, "User")))
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Dashboard", "Area");


        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var User = await _userManager.FindByNameAsync(rvm.Username);
            if (User != null)
            {
                ModelState.AddModelError(nameof(RegisterViewModel.Username), "This username is taken. Please enter another username");
                return View();
            }

            User user = new User()
            {
                UserName = rvm.Username,
                Name = rvm.Name,
                Surname = rvm.Surname,
                Email = rvm.Email,
                PhoneNumber = rvm.Phone,
                Gender = (await _dt.Gender.FindAsync(rvm.GenderId)).Name,
                ProfilePhoto = FileUtils.FileCreate(rvm.ProfilePicture, FileConstants.ImagePath)

            };

            var identityUser = await _userManager.CreateAsync(user, rvm.Password);

            if (!identityUser.Succeeded)
            {
                foreach (var item in identityUser.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    return View();
                }
            }

            await _signInManager.SignInAsync(user, true);
            await _userManager.AddToRoleAsync(user, RoleConstants.User);
            rvm.Email.SendConfirmationEmail();

            return RedirectToAction("Index", "Home");
        }
    }
}
