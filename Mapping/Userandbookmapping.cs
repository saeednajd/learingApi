using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapitwo.Model;

namespace webapitwo.Mapping
{
    public class Userandbookmapping : IEntityTypeConfiguration<Userandbook>
    {
        public void Configure(EntityTypeBuilder<Userandbook> builder)
        {
            builder.ToTable("Userandbook");
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.User).WithMany(x=>x.userandbooks).HasForeignKey(x=>x.Userid);
            builder.HasOne(x=>x.Book).WithMany(x=>x.userandbooks).HasForeignKey(x=>x.Bookid);
            
        }
    }
}