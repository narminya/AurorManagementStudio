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
        public AccountController(AurorDataContext dt,SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _dt = dt;
            _signInManager = signInManager;
            _userManager = userManager;
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
            if (user==null)
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

           

            return RedirectToAction(nameof(HomeController), nameof(HomeController.Index));
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel rvm)
        {
            rvm.Email.SendConfirmationEmail();
            return View();
        }
    }
}
