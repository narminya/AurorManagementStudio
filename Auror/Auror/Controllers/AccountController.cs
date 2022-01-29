﻿using Auror.Constants;
using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Auror.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });



        }

        public IActionResult Register()
        {
            var rgv = new RegisterViewModel()
            {
                Gender = _dt.Gender.ToList()
            };
            return View(rgv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            rvm.Gender = _dt.Gender.ToList();

            if (!ModelState.IsValid)
            {
                return View(rvm);
            }

            var dbUser = await _userManager.FindByNameAsync(rvm.Username);
            if (dbUser != null)
            {
                ModelState.AddModelError(rvm.Username, "This username is taken. Please enter another username");
                return View();
            }

            User user = new User();

            user.UserName = rvm.Username;
            user.Name = rvm.Name;
            user.Surname = rvm.Surname;
            user.Email = rvm.Email;
            user.GenderId = (await _dt.Gender.FindAsync(int.Parse(rvm.GenderId))).Id;
            //user.ProfilePhoto = FileUtils.FileCreate(rvm.ProfilePicture, FileConstants.ImagePath)



            var identityUser = await _userManager.CreateAsync(user, rvm.Password);

            if (!identityUser.Succeeded)
            {


                foreach (var item in identityUser.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    return View();
                }
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);

            Utilities.SendEmail.EmailSender(user.Email, "Please confirm your email", confirmationLink);
            await _userManager.ConfirmEmailAsync(user, token);


            await _signInManager.SignInAsync(user, true);
            await _userManager.AddToRoleAsync(user, RoleConstants.User);

            rvm.Email.EmailSender(Credentials.Message, Credentials.Body);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account", new { Area = "" });
        }

        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return NotFound();

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return BadRequest();
        }
    }
}
