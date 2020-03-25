using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationTestModel;

namespace MigrationTestModel.Data
{
    public class ModelUserMstConfig : IEntityTypeConfiguration<ModelUserMst>
    {
        public void Configure(EntityTypeBuilder<ModelUserMst> builder)
        {
            builder
                .ToTable("ModelUserMst")
                .HasKey(t => new { t.UserId, t.ModelId });
            
            builder
                .HasOne(t => t.ProductModelMst)
                .WithMany(m => m.ModelUserMsts)
                .HasForeignKey(f => f.ModelId)
                .HasPrincipalKey(p => p.ModelId);
        }
    }
}