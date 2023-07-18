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
        public async Task<IActionResult> Register(User user)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync("https://localhost:7264/api/Users/register", user);

            return RedirectToAction("Login", "Session");

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(User p)
        {

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync("https://localhost:7264/api/Users/login", p);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();

        }

        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}