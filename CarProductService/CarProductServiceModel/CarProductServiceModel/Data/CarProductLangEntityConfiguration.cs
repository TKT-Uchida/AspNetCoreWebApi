using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarProductServiceModel.Models;

namespace CarProductServiceModel.Data
{
    public class CarProductLangEntityConfiguration : IEntityTypeConfiguration<CarProductLang>
    {
        public void Configure(EntityTypeBuilder<CarProductLang> builder)
        {
            builder
                .ToTable("CAR_PRODUCT_LANG")
                .HasKey(t => new { t.ProductId, t.MakerId, t.LangId });
            
            builder
                .HasOne(p => p.CarProduct)
                // .HasOne<CarProduct>()
                .WithMany(l => l.CarProductLangs)
                .HasForeignKey(f => new { f.ProductId, f.MakerId })
                .HasConstraintName("FK_CAR_PRODUCT_LANG_CAR_PRODUCT");
        }
    }
}