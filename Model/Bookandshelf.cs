using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapitwo.Model
{
    public class Bookandshelf
    {
        public int Id { get; set; }
        public int Bookid { get; set; }
        public int Shelfid { get; set; }
        public Book Book { get; set; }
        public Shelf Shelf { get; set; }
    }
}