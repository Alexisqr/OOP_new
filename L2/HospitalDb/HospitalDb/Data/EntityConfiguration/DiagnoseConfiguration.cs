using HospitalDb.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDb.Data.EntityConfiguration
{
    public class DiagnoseConfiguration : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder.HasKey(n => n.DiagnoseId);

            builder.Property(n => n.Name)
                .IsUnicode()
                .HasMaxLength(30);

            builder.Property(n => n.Comments)
                .IsUnicode()
                .HasMaxLength(250);

            builder.HasOne(n => n.Patient)
                .WithMany(n => n.Diagnoses)
                .HasForeignKey(n => n.PatientId);
        }
    }
}
