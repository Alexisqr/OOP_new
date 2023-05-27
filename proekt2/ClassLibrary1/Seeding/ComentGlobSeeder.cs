using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShelterEF.DAL.Entities;
using ShelterEF.DAL.Seeding.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Seeding
{
    public class ComentGlobSeeder : ISeeder<ComentGlob>
    {
        private static readonly List<(ComentGlob, string)> globcoms = new()
        {
            (
                new ComentGlob
                {
                   // ID = 1,
                    IDVolonter=1,
                    Text= "---------------------------",
                    Date = "2022-06-16 00:00:00.000"

                },
                "User%password1"
            ),
            (
                new ComentGlob
                {
                  //  ID = 2,
                    IDVolonter=1,
                    Text= "++++++++++++++++++++++++++++++",
                    Date = "2022-06-16 00:00:00.000"

                },
                "User%password1"
            )
               
        };

        public void Seed(EntityTypeBuilder<ComentGlob> builder)
        {
            foreach (var globcom in globcoms)
            {
           
                builder.HasData(globcom);
            }
        }
    }
}
