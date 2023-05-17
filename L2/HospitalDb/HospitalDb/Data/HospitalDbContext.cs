using Microsoft.EntityFrameworkCore;
using System;
using HospitalDb.Data.Models;
using System.Linq;
using HospitalDb.Data.EntityConfiguration;
namespace HospitalDb.Data
{
    public class HospitalDbContext : DbContext
    {

        public HospitalDbContext()
        {
        }

        public HospitalDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PatientConfiguration());

            builder.ApplyConfiguration(new VisitationConfiguration());

            builder.ApplyConfiguration(new DiagnoseConfiguration());

            builder.ApplyConfiguration(new MedicamentConfiguration());

            builder.ApplyConfiguration(new PatientMedicamentConfiguration());


        }


    }

  
}