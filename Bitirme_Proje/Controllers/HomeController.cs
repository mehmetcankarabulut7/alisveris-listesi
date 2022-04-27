using Bitirme_Proje.Business.Interfaces;
using Bitirme_Proje.EntityFramework.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bitirme_Proje.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] string mail, string password)
        {
            if (GetRole(mail, password) == "admin")
            {
                await Authenticate(mail, password);
                HttpContext.Session.SetString("mail", mail);
                return RedirectToAction("Index", "Admin");
            }
            else if(_userService.GetByMailAndPassword(mail, password) is not null)
            {
                await Authenticate(mail, password);
                HttpContext.Session.SetString("mail", mail);
                return RedirectToAction("GetShoppingLists", "User");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm] User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            if(_userService.GetByMail(user.Mail) != null)
            {
                ModelState.AddModelError("Mail", "This e-mail address is used");
                return View(user);
            }

            _userService.Add(user);
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }

        private async Task Authenticate(string mail, string password)
        {
            await HttpContext.SignOutAsync();

            List<Claim> claims = new();
            claims.Add(new Claim(ClaimTypes.Email, mail));
            claims.Add(new Claim(ClaimTypes.Role, GetRole(mail, password)));
            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);   
        }

        private string GetRole(string mail, string password)
        {
            return (mail == "ad" && password == "ad") ? "admin" : "user";
        }
    }
}
