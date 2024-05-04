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

        public int Userid { get; set; }
        public User User { get; set; }

        public int Bookid { get; set; }
        public Book Book { get; set; }

        public int Shelfid { get; set; }
        public Shelf Shelf { get; set; }
        public Bookshelf(int bookstatus, int userid, int bookid, int shelfid)
    {
        Bookstatus = bookstatus;
        Userid = userid;
        Bookid = bookid;
        Shelfid = shelfid;
    }
        
    }
}