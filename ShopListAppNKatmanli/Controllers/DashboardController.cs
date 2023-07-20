using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ShopListAppNKatmanli.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Adresses()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adresses(AddressDTO dto)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://localhost:7297/api/Addresses/getAllAddresses");

            
            return View(response);
        }



    }
}
