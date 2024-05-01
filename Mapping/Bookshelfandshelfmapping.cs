using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapitwo.Model;

namespace webapitwo.Mapping
{
    public class Bookshelfandshelfmapping : IEntityTypeConfiguration<Bookshelfandshelf>
    {
        public void Configure(EntityTypeBuilder<Bookshelfandshelf> builder)
        {
            builder.ToTable("Bookshelfandshelf");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Bookshelf).WithMany(x => x.Bookshelfandshelves).HasForeignKey(x => x.Bookshelfid);
            builder.HasOne(x => x.Shelf).WithMany(x => x.Bookshelfandshelfs).HasForeignKey(x => x.Shelfid);
        }
    }
}