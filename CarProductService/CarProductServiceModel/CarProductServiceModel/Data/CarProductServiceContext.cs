using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarProductServiceModel.Models;

namespace CarProductServiceModel.Data
{
    public class CarProductServiceContext : DbContext
    {
        public CarProductServiceContext (DbContextOptions<CarProductServiceContext> options)
            : base(options)
        {
        }

        public DbSet<CarMaker> CarMaker { get; set; }

        public DbSet<CarMakerLang> CarMakerLang { get; set; }

        public DbSet<CarSalesYear> CarSalesYear { get; set; }

        public DbSet<CarProduct> CarProduct { get; set; }

        public DbSet<CarProductLang> CarProductLang { get; set; }

        public DbSet<CarProductModel> CarProductModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarMakerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CarMakerLangEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CarProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CarProductLangEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CarProductModelEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CarSalesYearEntityConfiguration());
        }
    }
}