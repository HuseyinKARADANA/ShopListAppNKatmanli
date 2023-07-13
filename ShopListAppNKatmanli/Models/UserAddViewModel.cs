﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopListAppNKatmanli.Models
{
    public class UserAddViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public bool Gender { get; set; }

        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }

        public DateTime RegisterDate { get; set; }

        public int PhoneNumber { get; set; }
    }
}