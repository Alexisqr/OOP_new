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
    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder.HasKey(ps => new { ps.PlayerId, ps.GameId });

            builder.Property(ps => ps.ScoredGoals)
                .IsRequired();

            builder.Property(ps => ps.Assists)
                .IsRequired();

            builder.Property(ps => ps.MinutesPlayed)
                .IsRequired();

            builder.HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId);

            builder.HasOne(ps => ps.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId);
        }
    }
}
