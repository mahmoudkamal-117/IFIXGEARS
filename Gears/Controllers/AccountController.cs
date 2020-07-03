using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gears.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gears.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginviewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginviewmodel);
            }
            var user = await _userManager.FindByNameAsync(loginviewmodel.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginviewmodel.Password, false, false);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Admin");

                }
            }
            ModelState.AddModelError("", "UserName Or PasswordNot Found");
            return View(loginviewmodel);
        }

        //public IActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(LoginViewModel loginviewmodel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new IdentityUser() { UserName = loginviewmodel.UserName };
        //        var result = await _userManager.CreateAsync(user, loginviewmodel.Password);
        //        if (result.Succeeded)
        //        {

        //            return RedirectToAction("Index", "Admin");
        //        }
        //    }
        //    return View(loginviewmodel);
        //}
      [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
