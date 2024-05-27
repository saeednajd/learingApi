using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapitwo.Model
{
    public class Shelf
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public int Userid { get; set; }

        public List<Bookshelf> Bookshelves { get; set; }
        public Shelf(String name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}