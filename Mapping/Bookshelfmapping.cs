using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapitwo.Model;

namespace webapitwo.Mapping
{
    public class Bookshelfmapping : IEntityTypeConfiguration<Bookshelf>
    {
        public void Configure(EntityTypeBuilder<Bookshelf> builder)
        {
            builder.ToTable("Bookshelf");
            builder.HasKey(x=>x.Id);
            builder.HasMany(x=>x.Bookshelfandbooks).WithOne(x=>x.Bookshelf).HasForeignKey(x=>x.Bookshelfid);
            builder.HasMany(X=>X.Bookshelfandshelves).WithOne(x=>x.Bookshelf).HasForeignKey(X=>X.Bookshelfid);
            builder.HasMany(x=>x.Bookshelfandusers).WithOne(x=>x.Bookshelf).HasForeignKey(x=>x.Bookshelfid);
        }
    }
}