using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student_System.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_System.Data.EntityConfiguration
{
    public class StudentsConfiguration : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder.HasKey(c => c.StudentId);

            builder.Property(c => c.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            builder.Property(c => c.PhoneNumber)
                .IsRequired(false)
                .IsUnicode(false)
                .HasDefaultValueSql("CHAR(10)");

            builder.Property(s => s.RegisteredOn)
                .IsRequired();

            builder.Property(s => s.Birthday)
                .IsRequired(false);

        }

    }
}

