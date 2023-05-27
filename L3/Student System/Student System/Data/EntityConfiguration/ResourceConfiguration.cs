using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student_System.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Student_System.Data.EntityConfiguration
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(c => c.ResourceId);

            builder.Property(c => c.Name)
     .IsRequired()
     .IsUnicode()
     .HasMaxLength(50);

            builder.Property(c => c.Url)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(c => c.ResourceType)
                .IsRequired();

            builder.HasOne(c => c.Course)
                .WithMany(s => s.Resources)
                .HasForeignKey(c => c.CourseId);
        }

    }
}
