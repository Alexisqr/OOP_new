using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShelterEF.DAL.Entities;
using TeamworkSystem.DataAccessLayer.Seeding;

namespace TeamworkSystem.DataAccessLayer.Configurations
{
    public class ComentGlobConfiguration : IEntityTypeConfiguration<ComentGlob>
    {
        public void Configure(EntityTypeBuilder<ComentGlob> builder)
        {
            //builder.HasKey(globcom => globcom.ID);

            builder.Property(globcom => globcom.IDVolonter)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(globcom => globcom.Text)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(globcom => globcom.Date)
                   .HasMaxLength(50);


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

