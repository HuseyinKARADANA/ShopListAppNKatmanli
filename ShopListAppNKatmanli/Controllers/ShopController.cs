using Microsoft.AspNetCore.Mvc;

namespace ShopListAppNKatmanli.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
