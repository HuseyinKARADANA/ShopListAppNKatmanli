using Microsoft.AspNetCore.Mvc;

namespace ShopListAppNKatmanli.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CartCss = "Cart";
            ViewBag.Cart = "active";
            return View();
        }
    }
}
