using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace webapitwo.Model
{
    public class User : IdentityUser
    {

        public DateTime Joindate { get; set; }

        public List<Bookshelf> Bookshelves { get; set; }

        public User()
        {

            Joindate = DateTime.Now;
        }
    }
}