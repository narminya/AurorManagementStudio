using Auror.Constants;
using Auror.Models.DataAccessLayer;
using Auror.Models.Entity;
using Auror.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AccountController> _logger;
        public AccountController(AurorDataContext dt, SignInManager<User> signInManager,
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
             ILogger<AccountController> logger
            )
        {
            _dt = dt;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;

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
            else if (user.EmailConfirmed == false)
            {
                ModelState.AddModelError(nameof(lvm.Email), "Please confirm your email address");
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



            await _userManager.AddToRoleAsync(user, RoleConstants.Visitor);

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
                await _userManager.AddToRoleAsync(user, RoleConstants.User);
                await _userManager.RemoveFromRoleAsync(user, RoleConstants.Visitor);
                return RedirectToAction("Index", "Home");
            }
            return BadRequest();
        }
        public async Task<IActionResult> PasswordChange(string id)
        {
            var user = await _dt.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var changePasswordViewModel = new ChangePasswordViewModel()
            {
                Id = user.Id,
                Username = user.UserName
            };
            return View(changePasswordViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PasswordChange(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ModelState.AddModelError("", "User is not found");
                return View();
            }
            var changePasswordViewModel = new ChangePasswordViewModel()
            {
                Id = user.Id,
                Username = user.UserName
            };

            var passwordcheck = await _userManager.CheckPasswordAsync(user, model.OldPassword);
            if (!passwordcheck)
            {
                ModelState.AddModelError("", "Old password is wrong");
                return View(changePasswordViewModel);
            }

            var passwordChangeResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!passwordChangeResult.Succeeded)
            {
                ModelState.AddModelError("", "Something went wrong,try again");
                return View();
            }

            return RedirectToAction("Detail", "User", new { area = "Admin", id = model.Id });
        }

        public IActionResult PasswordReset()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PasswordReset(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Please enter valid email");
                return View(model);
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetLink = Url.Action("NewPasswordReset", "Account", new { email = model.Email, token = token }, Request.Scheme);

            _logger.Log(LogLevel.Warning, passwordResetLink);
            Utilities.SendEmail.EmailSender(user.Email, "Change password", passwordResetLink);
            return View("PasswordResetConfirm", "Account");
        }

        public IActionResult PasswordResetConfirm()
        {
            return View();
        }

        public IActionResult NewPasswordReset(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset link");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewPasswordReset(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return View(model);
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    return View(model);
                }
            }



            if (User.IsInRole(RoleConstants.User))
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }
    }
}
