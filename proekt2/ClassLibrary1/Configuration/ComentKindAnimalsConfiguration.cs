using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShelterEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShelterDAL.Models;

namespace ShelterEF.DAL.Configuration
{
    public class ComentKindAnimalsConfiguration : IEntityTypeConfiguration<ComentKindAnimals>
    {
        public void Configure(EntityTypeBuilder<ComentKindAnimals> builder)
        {


            builder.HasKey(globcom => globcom.ID);

            builder.Property(globcom => globcom.Text)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(globcom => globcom.Date)
                   .HasMaxLength(50);

            builder.HasOne(e => e.Volonters)
          .WithMany(c => c.ComentKindAnimalss)
          .HasForeignKey(e => e.IDVolonter);

            builder.HasOne(e => e.KindOfAnimals)
          .WithMany(c => c.ComentKindAnimalss)
          .HasForeignKey(e => e.IDKindAnimals);

            // builder.HasMany(user => user.Friends)
            //        .WithMany(user => user.FriendForUsers)
            //        .UsingEntity(entity =>
            //        {
            //            entity.ToTable("Friends");
            //            entity.Property("FriendsId").HasColumnName("FirstId");
            //            entity.Property("FriendForUsersId").HasColumnName("SecondId");
            //        });

            //new ComentGlobSeeder().Seed(builder);
        }
    }
}
