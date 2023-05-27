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
        public ComentGlobRepository(MyContext myContext):base(myContext) { 
        }
        public override Task<ComentGlob> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
