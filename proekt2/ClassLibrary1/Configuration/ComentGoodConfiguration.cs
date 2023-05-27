using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShelterEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEF.DAL.Configuration
{
    public class ComentGoodConfiguration : IEntityTypeConfiguration<ComentGood>
    {
        public void Configure(EntityTypeBuilder<ComentGood> builder)
        {
           

            builder.HasKey(globcom => globcom.ID);

            builder.Property(globcom => globcom.Text)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(globcom => globcom.Date)
                   .HasMaxLength(50);

            builder.HasOne(e => e.Volonters)
          .WithMany(c => c.ComentGoods)
          .HasForeignKey(e => e.IDVolonter);

            builder.HasOne(e => e.Goods)
          .WithMany(c => c.ComentGoods)
          .HasForeignKey(e => e.IDGood);

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
