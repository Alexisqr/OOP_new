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
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(c => c.HomeworkId);

            builder.Property(c => c.Content)
               .IsRequired()
               .IsUnicode(false);
            builder.Property(c => c.ContentType)
                            .IsRequired();

            builder.Property(c => c.SubmissionTime)
                .IsRequired();

            builder.HasOne(c => c.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(c => c.StudentId);

            builder.HasOne(c => c.Course)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(c => c.CourseId);


        }

    }
}
