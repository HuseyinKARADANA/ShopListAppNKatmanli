using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using System.Data.SqlClient;
using DataAccessLayer.Abstract;

namespace ShoppingListApp.Mapping
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
        public ActionResult Register(IUserDal user )
        {
            
            return View();
        }


    }
}