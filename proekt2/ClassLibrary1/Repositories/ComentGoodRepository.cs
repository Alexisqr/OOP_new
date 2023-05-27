using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShelterEF.DAL.Data;
using ShelterEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShelterEF.DAL.Repositories.ComentGoodRepository;

namespace ShelterEF.DAL.Repositories
{
    public class ComentGoodRepository : GenericRepository<ComentGood>, IComentGoodRepository
    {
      
            public ComentGoodRepository(MyContext myContext) : base(myContext)
            {
            }

         //   public async Task<ComentGood> GetComentGoodAsync(int id)
         //   {
         //       return await table
          //          .Include(cg => cg.Text)  // Replace with the actual navigation property name
        //            .FirstOrDefaultAsync(cg => cg.ID == id);
         //   }

        public async Task<IEnumerable<ComentGood>> GetComentGood()
        {
           
            var results = await table.Include(project => project.Text)                             
                              .OrderByDescending(project => project.ID)
                              .Take(3)
                              .ToListAsync();

            return results;
        }
        public override Task<ComentGood> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
