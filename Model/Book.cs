using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapitwo.Model
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }


        public int Pages { get; set; }



        public List<Bookshelf> bookshelves
        {
            get; set;
        }

        public Book(string title, int pages)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Pages = pages;
        }

    }
}