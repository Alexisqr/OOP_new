using ShelterDAL.Models;

namespace Shelter.DAL.Repositories.Interfaces
{
    public interface IKindOfAnimalsRepository : IGenericRepository<KindOfAnimals>
    {
        Task<IEnumerable<KindOfAnimals>> GetKindOfAnimals();
    }
  
}
