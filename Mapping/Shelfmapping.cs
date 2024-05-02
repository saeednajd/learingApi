using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapitwo.Model;

namespace webapitwo.Mapping
{
    public class Shelfmapping : IEntityTypeConfiguration<Shelf>
    {
        public void Configure(EntityTypeBuilder<Shelf> builder)
        {
            builder.ToTable("Shelf");
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Name).HasMaxLength(255);


            builder.HasMany(x=>x.Bookshelfandshelfs).WithOne(x=>x.Shelf).HasForeignKey(x=>x.Shelfid);
            

        }

    }
}