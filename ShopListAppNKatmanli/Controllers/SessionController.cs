using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using EntityLayer.DTOs;

namespace ShopListAppNKatmanli.Controllers
{
    public class SessionController : Controller
    {


        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.register = "register";
            ViewBag.registerActive = "active";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDto)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync("https://localhost:7297/api/Users/register", registerDto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Session");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync("https://localhost:7297/api/Users/login", dto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }



            return View();

        }



        public async Task<ActionResult> LogOut()
        {


            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7297/api/Users/logout");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
