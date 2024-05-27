using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapitwo.Model;

namespace webapitwo.Mapping
{
    public class Userconfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            // builder.HasKey(x => x.Id);
            builder.HasMany(x=>x.Bookshelves).WithOne(x=>x.User).HasForeignKey(x=>x.Userid);

        }
    }
}