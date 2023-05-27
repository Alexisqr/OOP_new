using FootballBetting.Data.EntityConfiguration;
using FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBetting.Data
{

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(Config.ConnectionString);
            }
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BetConfiguration());

            builder.ApplyConfiguration(new ColorConfiguration());

            builder.ApplyConfiguration(new CountryConfiguration());

            builder.ApplyConfiguration(new GameConfiguration());

            builder.ApplyConfiguration(new PlayerConfiguration());

            builder.ApplyConfiguration(new PositionConfiguration());

            builder.ApplyConfiguration(new TeamConfiguration());

            builder.ApplyConfiguration(new TownConfiguration());

            builder.ApplyConfiguration(new PlayerStatisticConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());

            
        }
       

    }
}