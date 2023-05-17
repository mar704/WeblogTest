using BlogManagement.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogManagement.Controllers
{
   


    public class AccountController : Controller
    {
        //private readonly SignInManager<User> _signInManager;

        //public AccountController(SignInManager<User> signInManager)
        //{
        //    _signInManager = signInManager;
        //}

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            
         
            if (IsValidUser(username, password))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
                
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
            

            ModelState.AddModelError(string.Empty, "Invalid username or password");
            return View();

           
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        private bool IsValidUser(string username, string password)
        {
            
            if (username == "admin" && password == "123456")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

           
        }

}
