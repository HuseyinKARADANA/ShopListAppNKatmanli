using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using System.Data.SqlClient;
using DataAccessLayer.Abstract;
using ShopListAppNKatmanli.Models;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using BusinessLayer.Abstract;

namespace ShoppingListApp.Mapping
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
            return View(new UserViewModel());
        }

        [HttpPost]
        public ActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("buraya geldi");
                var user=new User()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    Gender = model.Gender,
                    BirthDate = model.BirthDate,
                    PhoneNumber = model.PhoneNumber,
                    RegisterDate = System.DateTime.Now,
                    UserName = model.UserName,
                    Password = model.Password,
                };
                _userService.Insert(user);

                return RedirectToAction("Index", "Home");

                
            }
            ViewBag.register = "register";
            ViewBag.registerActive = "active";
            return View(model);

        }

        [HttpGet]//Default
        public IActionResult Login()
        {
            ViewBag.login = "register";
            ViewBag.loginActive = "active";
            return View();
        }


        [HttpPost]
        public IActionResult Login(User newUser)
        {

           

            ViewBag.login = "register";
            ViewBag.loginActive = "active";
            return RedirectToAction("Login", "Session");
        }
    }
}