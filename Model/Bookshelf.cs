using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapitwo.Model
{
    public class Bookshelf
    {
        public int Id { get; set; }
        public int Bookstatus { get; set; }

        public int Bookshelfandbookid { get; set; }
        public List<Bookshelfandbook> Bookshelfandbooks { get; set; }


        public int Bookshelfandshelfid { get; set; }
        public List<Bookshelfandshelf> Bookshelfandshelves { get; set; }

        public int Bookshelfanduserid { get; set; }
        public List<Bookshelfanduser> Bookshelfandusers { get; set; }

        public Bookshelf(int bookstatus)
        {

            Bookstatus = bookstatus;

        }
    }
}