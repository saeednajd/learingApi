using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapitwo.Model
{
    public class Bookshelfanduser
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Bookshelfid { get; set; }
        public User User { get; set; }
        public Bookshelf Bookshelf { get; set; }
    }
}