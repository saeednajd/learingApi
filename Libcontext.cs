using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapitwo.Mapping;
using webapitwo.Model;

namespace webapitwo
{
    public class Libcontext : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Shelf> Shelves { get; set; }

        DbSet<Bookshelf> Bookshelves { get; set; }

        public Libcontext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Usermapping());
            modelBuilder.ApplyConfiguration(new Shelfmapping());
            modelBuilder.ApplyConfiguration(new Userandbookmapping());
            modelBuilder.ApplyConfiguration(new Bookshelfmapping());
            modelBuilder.ApplyConfiguration(new Bookshelfandshelfmapping());
            modelBuilder.ApplyConfiguration(new Bookshelfandbookmapping());
            modelBuilder.ApplyConfiguration(new Bookandshelfmapping());
            modelBuilder.ApplyConfiguration(new Boohshelfandusermapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}