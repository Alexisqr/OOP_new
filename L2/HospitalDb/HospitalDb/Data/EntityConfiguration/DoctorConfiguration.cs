using HospitalDb.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace HospitalDb.Data.EntityConfiguration
{
    public class DoctorConfiguration : EntityTypeConfiguration<Doctor>
    {
        public DoctorConfiguration()
        {
            ToTable("Doctor").HasKey(p => p.DoctorId);
            Property(p => p.Name).IsUnicode().HasMaxLength(50);


            Property(d => d.Name)
                .IsUnicode()
            .HasMaxLength(100);

            Property(d => d.Specialty)
                .IsUnicode()
                .HasMaxLength(100);
     

        }
    }
}
