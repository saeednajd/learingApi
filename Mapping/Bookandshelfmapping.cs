using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapitwo.Model;

namespace webapitwo.Mapping
{
    public class Bookandshelfmapping : IEntityTypeConfiguration<Bookandshelf>
    {
        public void Configure(EntityTypeBuilder<Bookandshelf> builder)
        {
            builder.ToTable("Bookandshelf");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Book).WithMany(x => x.Bookandshelves).HasForeignKey(x => x.Bookid);
            builder.HasOne(x=>x.Shelf).WithMany(x=>x.Bookandshelfs).HasForeignKey(x=>x.Shelfid);
            
        }
    }
}