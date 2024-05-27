using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapitwo.Mapping;
using webapitwo.Model;

namespace webapitwo
{
    public class Libcontext : IdentityDbContext<User>
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



            SeedrRoles(modelBuilder);
            SeedUsers(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }
        public static void SeedrRoles(ModelBuilder x)
        {
            x.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "ADMIN"
                }, new IdentityRole
                {
                    Name = "User",
                    ConcurrencyStamp = "2",
                    NormalizedName = "USER"
                }
            );
        }
        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserName = "admin@example.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!")
                },
                new User
                {
                    UserName = "user@example.com",
                    NormalizedUserName = "USER@EXAMPLE.COM",
                    Email = "user@example.com",
                    NormalizedEmail = "USER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User123!")
                }
            );
        }


    }
}