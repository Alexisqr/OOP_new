using Microsoft.EntityFrameworkCore;
using SalesDb.Data.EntityConfiguration;
using SalesDb.Data.Models;
using SalesDb;
using System;
using System.Linq;


namespace SalesDB.Data
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext()
        {
        }

        public SalesDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Custumers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stors { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustumerConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());

            builder.ApplyConfiguration(new SaleConfiguration());

            builder.ApplyConfiguration(new StoreConfiguration());



        }


    }
}