using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationTestModel;

namespace MigrationTestModel.Data
{
    public class ProductModelMstConfig : IEntityTypeConfiguration<ProductModelMst>
    {
        public void Configure(EntityTypeBuilder<ProductModelMst> builder)
        {
            builder
                .ToTable("ProductModelMst")
                .HasKey(t => new { t.ProductId, t.ModelId });
            
            // builder
            //     .HasAlternateKey(a => a.ModelId);
        }
    }
}