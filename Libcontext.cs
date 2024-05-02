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
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Shelf> Shelves { get; set; }

        public DbSet<Bookshelf> Bookshelves { get; set; }

        public Libcontext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Usermapping());
            modelBuilder.ApplyConfiguration(new Shelfmapping());
            modelBuilder.ApplyConfiguration(new Bookshelfmapping());
            modelBuilder.ApplyConfiguration(new Bookshelfandshelfmapping());
            modelBuilder.ApplyConfiguration(new Bookshelfandbookmapping());
            modelBuilder.ApplyConfiguration(new Boohshelfandusermapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}