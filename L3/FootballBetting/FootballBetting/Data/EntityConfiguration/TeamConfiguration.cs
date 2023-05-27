using FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBetting.Data.EntityConfiguration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.TeamId);

            builder.Property(t => t.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(t => t.LogoUrl)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(t => t.Initials)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(3)
                .HasDefaultValueSql("CHAR(3)");

            builder.HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
            .OnDelete(DeleteBehavior.NoAction);



            builder.HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(t => t.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TownId)
            .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
