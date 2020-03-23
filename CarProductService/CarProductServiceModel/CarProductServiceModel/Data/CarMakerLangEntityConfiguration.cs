using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarProductServiceModel.Models;

namespace CarProductServiceModel.Data
{
    public class CarMakerLangEntityConfiguration : IEntityTypeConfiguration<CarMakerLang>
    {
        public void Configure(EntityTypeBuilder<CarMakerLang> builder)
        {
            builder
                .ToTable("CAR_MAKER_LANG")
                .HasKey(t => new { t.LangId, t.MakerId });
            
            builder
                .HasOne(m => m.CarMaker)
                // .HasOne<CarMaker>()
                .WithMany(l => l.CarMakerLangs)
                .HasForeignKey(f => f.MakerId)
                .HasConstraintName("FK_CAR_MAKER_LANG_CAR_MAKER");
        }
    }
}