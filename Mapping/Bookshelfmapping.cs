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
            
        }
    }
}