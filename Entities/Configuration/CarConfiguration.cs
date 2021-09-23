using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
      
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasOne(x => x.Brand)
                .WithMany()
                .HasForeignKey(x => x.BrandId)
                 .OnDelete(DeleteBehavior.Cascade);
                builder.Property(x => x.ModelName).IsRequired();
                builder.Property(x => x.BrandId).IsRequired();


        }
       
    }
}
