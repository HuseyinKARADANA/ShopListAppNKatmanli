﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopListAppNKatmanli.Models;
using System.Diagnostics;

namespace ShopListAppNKatmanli.Controllers
{
    [Authorize(Roles ="User")]
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            @ViewBag.IndexCss = "Index";
            @ViewBag.Index = "active";
            return View();
        }

       

       
    }
}