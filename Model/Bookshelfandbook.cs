using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapitwo.Model
{
    public class Bookshelfandbook
    {
        public int Id { get; set; }

        public int Bookid { get; set; }
        public int Bookshelfid { get; set; }

        public Book Book { get; set; }
        public Bookshelf Bookshelf { get; set; }
    }
}