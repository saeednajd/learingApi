using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapitwo.Model
{
    public class Bookshelfandshelf
    {
        public int Id { get; set; }
        public int Bookshelfid { get; set; }
        public int Shelfid { get; set; }
        public Bookshelf Bookshelf { get; set; }
        public Shelf Shelf { get; set; }

        public Bookshelfandshelf(int bookshelfid,int shelfid){
            Bookshelfid = bookshelfid;
            Shelfid = shelfid;

        }
    }
}