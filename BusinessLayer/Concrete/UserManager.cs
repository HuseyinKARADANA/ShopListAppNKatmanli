﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager:IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Delete(User t)
        {
            _userDal.Delete(t);
        }

        public User GetElementById(int id)
        {
            return _userDal.GetElementById(id);
        }

        public List<User> GetListAll()
        {
            return _userDal.GetListAll();
        }

        public void Insert(User t)
        {
            _userDal.Insert(t);
        }

        public void Update(User t)
        {
            _userDal.Update(t);
        }

        public bool Login(User newUser)
        {
            // Check if email and password are provided
            if (newUser.Password != null && newUser.Email != null)
            {
                // Find the user with the provided email and password
                var user = _userDal.GetListAll()
                    .FirstOrDefault(x => x.Email == newUser.Email && x.Password == newUser.Password);

                if (user != null)
                {
                    // User exists, perform the necessary actions
                    // For example, you can set user-related information in the session or perform any other business logic.

                    return true;
                }
            }

            return false;
        }

    }
}