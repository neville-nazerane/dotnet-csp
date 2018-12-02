using DotnetCsp.Core;
using DotnetCsp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DotnetCsp.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace DotnetCsp.Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly IDisplayUserRepository displayUserRepository;

        public AccountController(SignInManager<User> signInManager, IDisplayUserRepository displayUserRepository)
        {
            this.signInManager = signInManager;
            this.displayUserRepository = displayUserRepository;
        }

        public IEnumerable<User> All() => signInManager.UserManager.Users;

        [HttpGet]
        public IActionResult Login(string ReturnUrl) 
            => View(new Login { ReturnUrl = ReturnUrl });

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var res = await signInManager.PasswordSignInAsync(login.UserName, login.Password, true, false);
            if (res.Succeeded)
            {
                var user = signInManager.UserManager.Users.SingleOrDefault(u => u.UserName == login.UserName);
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                };
                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "local")));
                if (string.IsNullOrEmpty(login.ReturnUrl)) return Redirect("~/");
                else return Redirect("~" + login.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid Login!");
                return View(login);
            }
        }

        [HttpGet]
        public IActionResult SignUp() => View();

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUp signUp)
        {
            
            if (ModelState.IsValid)
            {
                var res = await signInManager.UserManager.CreateAsync(
                                                new User
                                                {
                                                    UserName = signUp.UserName,
                                                    Email = signUp.Email
                                                },
                                                signUp.Password);
                if (res.Succeeded)
                {
                    displayUserRepository.Add(signUp.UserName);
                    return Redirect("~/");
                }
                else
                    foreach (var err in res.Errors)
                        ModelState.AddModelError("", err.Description);
            }
            return View(signUp);
        }


    }
}
