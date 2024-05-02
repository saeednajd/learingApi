using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace webapitwo.Model
{
    public class User
    {


        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Joindate { get; set; }



        public int Bookshelfanduserid { get; set; }
        public List<Bookshelfanduser> Bookshelfandusers { get; set; }

        
        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Joindate = DateTime.Now;
        }
    }
}