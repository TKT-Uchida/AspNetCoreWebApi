using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarProductServiceModel.Models;

namespace CarProductServiceModel.Data
{
    public class CarProductModelEntityConfiguration : IEntityTypeConfiguration<CarProductModel>
    {
        public void Configure(EntityTypeBuilder<CarProductModel> builder)
        {
            builder
                .ToTable("CAR_PRODUCT_MODEL")
                .HasKey(t => t.ModelId);
            
            builder
                .HasOne(p => p.CarProduct)
                // .HasOne<CarProduct>()
                .WithMany(m => m.CarProductModels)
                .HasForeignKey(f => new { f.ProductId, f.MakerId })
                .HasConstraintName("FK_CAR_PRODUCT_MODEL_CAR_PRODUCT");
        }
    }
}