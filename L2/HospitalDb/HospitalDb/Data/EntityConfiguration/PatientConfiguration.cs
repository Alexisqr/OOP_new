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
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.PatientId);

            builder.Property(p => p.FirstName)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(p => p.Address)
                .IsUnicode()
                .HasMaxLength(250);

            builder.Property(p => p.Email)
                .IsUnicode(false)
                .HasMaxLength(80);
            //використовується для визначення значення за замовчуванням для стовпця бази даних,
            //зіставленого з властивістю. Значення має бути постійним.
            builder.Property(p => p.HasInsurance)
                .HasDefaultValue(true);
        }
    }
}
