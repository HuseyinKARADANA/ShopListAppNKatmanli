using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using System.Data.SqlClient;
using DataAccessLayer.Abstract;
using ShopListAppNKatmanli.Models;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using BusinessLayer.Abstract;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace ShopListAppNKatmanli.Controllers
{
    public class SessionController : Controller
    {
        private readonly IUserService _userService;
        
        public SessionController(IUserService userService)
        {
            _userService = userService;
            
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.register = "register";
            ViewBag.registerActive = "active";
            return View(new UserViewModel());
        }

        [HttpPost]
        public ActionResult Register(UserViewModel model)
        {
            
            
                _userService.Insert(new User()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    Gender = model.Gender,
                    BirthDate = model.BirthDate,
                    PhoneNumber = model.PhoneNumber,
                    RegisterDate = System.DateTime.Now,
                    UserName = model.UserName,
                    Password = model.Password
                });
               

                return RedirectToAction("Login", "Session");


        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.login = "login";
            ViewBag.loginActive = "active";
            return View();
        }


        [HttpPost]
        public async Task<IActionResult>Login(User p)
        {
            var isLoggedIn = _userService.Login(p.Email, p.Password);
            if (isLoggedIn)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.Email),
                    new Claim(ClaimTypes.Role, "User")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var authenticationProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);

                return RedirectToAction("Index", "Home");
            }
            
            ViewBag.login = "login";
            ViewBag.loginActive = "active";
            return View();

        }

        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}