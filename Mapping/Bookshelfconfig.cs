using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapitwo.Model;

namespace webapitwo.Mapping
{
    public class Bookshelfconfig : IEntityTypeConfiguration<Bookshelf>
    {
        public void Configure(EntityTypeBuilder<Bookshelf> builder)
        {
            builder.ToTable("Bookshelf");
            builder.HasKey(x => x.Id);

            builder.HasOne
            (x => x.User).WithMany(x => x.Bookshelves).HasForeignKey(x => x.Userid);
            builder.HasOne(x => x.Book).WithMany(x => x.bookshelves).HasForeignKey(x => x.Bookid);

            builder.HasOne(x => x.Shelf).WithMany(x => x.Bookshelves).HasForeignKey(x => x.Shelfid);


        }
    }
}