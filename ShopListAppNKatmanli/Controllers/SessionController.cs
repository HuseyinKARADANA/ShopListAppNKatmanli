using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using System.Data.SqlClient;
using DataAccessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using BusinessLayer.Abstract;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var httpClient = new HttpClient();

            //Serializing the user object
            /*var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");*/

            //Sending a response with the serialized json format
            var response = await httpClient.PostAsJsonAsync("https://localhost:7264/api/Users/register", user);

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
        public async Task<IActionResult> Login(User p)
        {

            //var httpClient = new HttpClient();
            //var response = await httpClient.PostAsJsonAsync("https://localhost:7264/api/Users/login", p);

            //if (response.ıssuccessstatuscode)
            //{
            //    return redirecttoaction("ındex", "home");
            //}

            var a = Login2(new LoginDTO() { Email=p.Email, Password=p.Password});

            return View();

        }

        public async Task<User> Login2(LoginDTO loginDto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpResponseMessage res = await client.PostAsJsonAsync("https://localhost:7297/api/Users/login", loginDto))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (res.StatusCode != HttpStatusCode.InternalServerError && res.StatusCode != HttpStatusCode.Conflict)
                        {
                            var result = JsonConvert.DeserializeObject<User>(data);
                            return result;
                        }
                        else
                        {
                            User? resultError = JsonConvert.DeserializeObject<User>(data);
                            return resultError;
                        }
                    }

                }
            }
            var a = "";
        }

        public async Task<ActionResult> LogOut()
        {
            User p = new User();

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync("https://localhost:7264/api/Users/logout", p);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}