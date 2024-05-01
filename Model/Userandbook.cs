using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapitwo.Model
{
    public class Userandbook
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Bookid { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}