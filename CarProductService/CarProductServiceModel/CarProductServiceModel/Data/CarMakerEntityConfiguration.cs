using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarProductServiceModel.Models;

namespace CarProductServiceModel.Data
{
    public class CarMakerEntityConfiguration : IEntityTypeConfiguration<CarMaker>
    {
        public void Configure(EntityTypeBuilder<CarMaker> builder)
        {
            builder
                .ToTable("CAR_MAKER")
                .HasKey(t => t.MakerId);
        }
    }
}