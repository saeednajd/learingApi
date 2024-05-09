using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace webapitwo.Model
{
    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime Joindate { get; set; }

        public List<Bookshelf> Bookshelves { get; set; }

        public User(string username, string password, String role)
        {
            Username = username;
            Password = password;
            Joindate = DateTime.Now;
            Role = role;
        }

    }
}