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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.Name)
                 .IsRequired()
                .IsUnicode()
                .HasMaxLength(80);

            builder.Property(c => c.Description)
               .IsUnicode()
              .IsRequired(false);

            builder.Property(c => c.StartDate)
        
               .IsRequired();


            builder.Property(c => c.EndDate)
           
              .IsRequired();

            builder.Property(c => c.Price)
               
                 .IsRequired();


        }

    }
}
