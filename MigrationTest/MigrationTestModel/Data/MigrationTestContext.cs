using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MigrationTestModel;

namespace MigrationTestModel.Data
{
    public class MigrationTestContext : DbContext
    {
        public MigrationTestContext (DbContextOptions<MigrationTestContext> options)
            : base(options)
        {
        }

        public DbSet<ProductMst> CarMaker { get; set; }

        public DbSet<ProductMstChild> CarMakerLang { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMstConfig());
            modelBuilder.ApplyConfiguration(new ProductMstChildConfig());
            modelBuilder.ApplyConfiguration(new ProductModelMstConfig());
            modelBuilder.ApplyConfiguration(new ModelUserMstConfig());
        }
    }
}