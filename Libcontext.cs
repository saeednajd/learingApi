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
            modelBuilder.ApplyConfiguration(new Userconfig());
            modelBuilder.ApplyConfiguration(new Bookconfig());
            modelBuilder.ApplyConfiguration(new Shelfconfig());
            modelBuilder.ApplyConfiguration(new Bookshelfconfig());





            base.OnModelCreating(modelBuilder);
        }
    }
}