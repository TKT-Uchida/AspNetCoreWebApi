using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationTestModel;

namespace MigrationTestModel.Data
{
    public class ProductMstConfig : IEntityTypeConfiguration<ProductMst>
    {
        public void Configure(EntityTypeBuilder<ProductMst> builder)
        {
            builder
                .ToTable("ProductMst")
                .HasKey(t => t.ProductId);
        }
    }
}