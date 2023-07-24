using EntityLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace ShopListAppNKatmanli.Controllers
{
    
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
           
            return View();
        }

        [HttpGet]

        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Contact(MailDTO mail)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync("https://localhost:7297/api/Mail", mail);


            return RedirectToAction("Contact","Home");
        }




    }
}