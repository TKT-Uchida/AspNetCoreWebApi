using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarProductServiceModel.Models;

namespace CarProductServiceModel.Data
{
    public class CarProductEntityConfiguration : IEntityTypeConfiguration<CarProduct>
    {
        public void Configure(EntityTypeBuilder<CarProduct> builder)
        {
            builder
                .ToTable("CAR_PRODUCT")
                .HasKey(t => new { t.ProductId, t.MakerId });
            
            builder
                .HasOne(m => m.CarMaker)
                // .HasOne<CarMaker>()
                .WithMany(p => p.CarProducts)
                .HasForeignKey(f => f.MakerId)
                .HasConstraintName("FK_CAR_PRODUCT_CAR_MAKER");
        }
    }
}