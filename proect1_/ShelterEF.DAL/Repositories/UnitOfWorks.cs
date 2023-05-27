using ShelterEF.DAL.Data;
using ShelterEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEF.DAL.Repositories
{
    public class UnitOfWorks : IUnitOfWorks
    {
        protected readonly MyContext databaseContext;

        public IComentGlobRepository Globcom { get; } 

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public Task SeveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public UnitOfWorks(
            MyContext databaseContext,
            IComentGlobRepository ComentGlobManager
           )
        {
            this.databaseContext = databaseContext;
            this.Globcom = ComentGlobManager;

        }

    }
}
