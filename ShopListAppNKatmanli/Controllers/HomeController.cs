using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopListAppNKatmanli.Models;
using System.Diagnostics;

namespace ShopListAppNKatmanli.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
           
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }

       

       
    }
}