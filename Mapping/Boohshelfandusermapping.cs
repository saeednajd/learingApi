using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapitwo.Model;

namespace webapitwo.Mapping
{
    public class Boohshelfandusermapping : IEntityTypeConfiguration<Bookshelfanduser>
    {
        public void Configure(EntityTypeBuilder<Bookshelfanduser> builder)
        {
            builder.ToTable("Bookshelfanduser");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User).WithMany(x => x.Bookshelfandusers).HasForeignKey(x => x.Userid);
            builder.HasOne(x=>x.Bookshelf).WithMany(x=>x.Bookshelfandusers).HasForeignKey(x=>x.Bookshelfid);
        }
    }
}