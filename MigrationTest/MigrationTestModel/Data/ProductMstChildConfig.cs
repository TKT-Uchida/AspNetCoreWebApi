using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationTestModel;

namespace MigrationTestModel.Data
{
    public class ProductMstChildConfig : IEntityTypeConfiguration<ProductMstChild>
    {
        public void Configure(EntityTypeBuilder<ProductMstChild> builder)
        {
            builder
                .ToTable("ProductMstChild")
                .HasKey(t => new { t.ParenctProductId, t.ChildProductId });

            builder
                .HasOne(t => t.ParentProductMst)
                .WithMany(m => m.ProductMstParent)
                .HasForeignKey(f => f.ParenctProductId);
            
            builder
                .HasOne(t => t.ChildProductMst)
                .WithMany(m => m.ProductMstChild)
                .HasForeignKey(f => f.ChildProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}