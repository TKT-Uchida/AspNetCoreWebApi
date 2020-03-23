using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarProductServiceModel.Models;

namespace CarProductServiceModel.Data
{
    public class CarSalesYearEntityConfiguration : IEntityTypeConfiguration<CarSalesYear>
    {
        public void Configure(EntityTypeBuilder<CarSalesYear> builder)
        {
            builder
                .ToTable("CAR_SALES_YEAR")
                .HasKey(t => t.CarSalesId);
            
            builder
                .HasOne(m => m.CarMaker)
                // .HasOne<CarMaker>()
                .WithMany(s => s.CarSalesYears)
                .HasForeignKey(f => f.MakerId)
                .HasConstraintName("FK_CAR_SALES_YEAR_CAR_MAKER");
        }
    }
}