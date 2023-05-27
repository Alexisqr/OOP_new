using ShelterDAL.Models;

namespace Shelter.DAL.Repositories.Interfaces
{
    public interface IAnimalsRepository : IGenericRepository<Animals>
    {
        Task<IEnumerable<Animals>> GetAnimals();
    }

}
