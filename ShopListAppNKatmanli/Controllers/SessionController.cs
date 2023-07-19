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
        public async Task<IActionResult> Register(RegisterDTO p)
        {
            var httpClient = new HttpClient();

            //Serializing the user object
            /*var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");*/

            //Sending a response with the serialized json format
            var response = await httpClient.PostAsJsonAsync("https://localhost:7297/api/Users/register", p);

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
                var response = httpClient.GetAsync("https://localhost:7297/api/Users/logout");
            

                return RedirectToAction("Login", "Session");
            

            
        }
    }
}
