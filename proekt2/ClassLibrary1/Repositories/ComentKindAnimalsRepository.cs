using Microsoft.EntityFrameworkCore;
using ShelterDAL.Models;
using ShelterEF.DAL.Data;
using ShelterEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEF.DAL.Repositories
{
    public class ComentKindAnimalsRepository : GenericRepository<ComentKindAnimals>, IComentKindAnimalsRepository
    {
        public ComentKindAnimalsRepository(MyContext myContext) : base(myContext)
        {
        }

        public async Task<IEnumerable<ComentKindAnimals>> GetComentKindAnimals()
        {

            var results = await table.Include(project => project.Text)
                              .OrderByDescending(project => project.ID)
                              .Take(3)
                              .ToListAsync();

            return results;
        }
        public override Task<ComentKindAnimals> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
