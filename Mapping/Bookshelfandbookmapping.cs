using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapitwo.Model;

namespace webapitwo.Mapping
{
    public class Bookshelfandbookmapping : IEntityTypeConfiguration<Bookshelfandbook>
    {
        public void Configure(EntityTypeBuilder<Bookshelfandbook> builder)
        {
            builder.ToTable("Bookshelfandbook");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Bookshelf).WithMany(x => x.Bookshelfandbooks).HasForeignKey(x => x.Bookshelfid);
            builder.HasOne(x => x.Book).WithMany(x => x.Bookshelfandbooks).HasForeignKey(x => x.Bookid);
        }
    }
}