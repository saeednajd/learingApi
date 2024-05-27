using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace webapitwo.Model
{
    public class Bookshelf
    {



        public string Id { get; set; }
        public int Bookstatus { get; set; }

        public string Userid { get; set; }
        public User User { get; set; }

        public string Bookid { get; set; }
        public Book Book { get; set; }

        public string Shelfid { get; set; }
        public Shelf Shelf { get; set; }
        public Bookshelf(int bookstatus, string userid, string bookid, string shelfid)
        {
            Id = Guid.NewGuid().ToString();
            Bookstatus = bookstatus;
            Userid = userid;
            Bookid = bookid;
            Shelfid = shelfid;
        }
        public void UpdateStatus(int status)
        {
            Bookstatus = status;
        }

    }
}