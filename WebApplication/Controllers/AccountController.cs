using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            //ViewData
            //ViewBag
            //TempData
            
            if (viewModel.Password != "password")
            {
                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Niepoprawna nazwa użytkownika lub hasło");
                ModelState.AddModelError(nameof(LoginViewModel.Password), "Niepoprawna nazwa użytkownika lub hasło");
                return View(viewModel);
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, 123.ToString()),
                new Claim(ClaimTypes.GivenName, "Jan"),
                new Claim(ClaimTypes.Surname, "Kowalski"),
                new Claim(ClaimTypes.Name, viewModel.UserName)
            };

            var userIdentity = new ClaimsIdentity
            (
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme,
                ClaimTypes.GivenName,
                ClaimTypes.Role
            );

            var properties = new AuthenticationProperties
            {
                IsPersistent = viewModel.RememberMe
            };

            var principal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(principal, properties);
            
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}