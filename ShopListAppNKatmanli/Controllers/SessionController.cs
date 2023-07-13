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
        private readonly IUserDal _userService;

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.register = "register";
            ViewBag.registerActive = "active";
            return View(new UserAddViewModel());
        }

        [HttpPost]
        public ActionResult Register(UserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.Insert(new User()
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
                });

                return RedirectToAction("Index", "Home");


            }
            ViewBag.register = "register";
            ViewBag.registerActive = "active";
            return View(model);

        }
    }
}