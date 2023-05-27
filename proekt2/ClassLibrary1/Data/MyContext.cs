using Microsoft.EntityFrameworkCore;
using ShelterDAL.Models;
using ShelterEF.DAL.Configuration;
using ShelterEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace ShelterEF.DAL.Data
{
    public class MyContext : DbContext
    {
       // public MyContext() { }
        public MyContext(DbContextOptions<MyContext> options)
         : base(options)
        {

        }

        public DbSet<ComentGlob> ComentGlobs { get; set; }
        public DbSet<ComentGood> ComentGoods{ get; set; }
        public DbSet<ComentKindAnimals> ComentKindAnimalss { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocalDB;Database=Test;Trusted_Connection=True;");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ComentGlobConfiguration());
            modelBuilder.ApplyConfiguration(new ComentGoodConfiguration());
            modelBuilder.ApplyConfiguration(new ComentKindAnimalsConfiguration());
        }
     

    }
}

