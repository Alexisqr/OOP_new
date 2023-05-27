using Microsoft.EntityFrameworkCore;
using ShelterEF.DAL.Data;
using ShelterEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEF.DAL.Repositories
{
    public class ComentGlobRepository : GenericRepository<ComentGlob>, IComentGlobRepository
    {
        public ComentGlobRepository(MyContext myContext) : base(myContext)
        {
        }

        //   public async Task<ComentGlob> GetComentGlobAsync(int id)
        //   {
        //       var comentGood = await table.FindAsync(id);
        //       if (comentGood != null)
        //       {
        ///           table.Entry(comentGood)
        ///               .Reference(cg => cg.Text)  
        //               .Load();
        //       }
        //       return comentGood;
        //   }
        public async Task<IEnumerable<ComentGlob>> GetComentGlob()
        {

            var results = await table.Include(project => project.Text)
                              .OrderByDescending(project => project.ID)
                              .Take(3)
                              .ToListAsync();

            return results;
        }
        public override Task<ComentGlob> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
