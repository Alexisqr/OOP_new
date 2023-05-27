using Microsoft.EntityFrameworkCore;
using System;

using System.Linq;
using BillsPaymentSystem.Data.Config;
using BillsPaymentSystem.Data.Config.EntityConfiguration;
using BillsPaymentSystem.Datas.Models;
using System.Net.Mime;
using System.Security.AccessControl;

namespace BillsPaymentSystem.Data
{
    public class BillsPaymentSystemContext : DbContext
    {
        public BillsPaymentSystemContext()
        {
        }

        public BillsPaymentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet <User> Users { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbContextConfig.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentMethodConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new CreditCardConfig());
            modelBuilder.ApplyConfiguration(new BankAccountConfig());
            Seeder(modelBuilder);
        }

        public static void Seeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
        new User { UserId = 1, FirstName = "LALALA", LastName = "PAPAPA", Email = "alexis.cv1824@gmail.com", Password = "12345" }


    );
            modelBuilder.Entity<BankAccount>().HasData(
             new BankAccount { BankAccountId = 1, Balance = 0.6M, BankName = "1234567891", SWIFT = "12-06-2018"},
             new BankAccount { BankAccountId = 2, Balance = 0.8M, BankName = "1234567891", SWIFT = "12-06-2018"}

         );
            modelBuilder.Entity<CreditCard>().HasData(
            new CreditCard { CreditCardId = 1, Limit = 0.7M, MoneyOwed = 0.9M, ExpirationDate = DateTime.ParseExact("12-06-2018", "dd-MM-yyyy", null) }


        );
            modelBuilder.Entity<PaymentMethod>().HasData(
          new PaymentMethod { Id = 1, UserId = 1, BankAccountId = 1,CreditCardId = 1,Type = PaymentType.BankAccount }


      );
            
        }

    }
}
