using Dapper;
using Shelter.DAL.Repositories;
using Shelter.DAL.Repositories.Interfaces;
using ShelterDAL.Models;
using System.Data;
using System.Data.SqlClient;

namespace Shelter.DAL.Repositories
{
    public class AnimalsRepository : GenericRepository<Animals>, IAnimalsRepository
    {
        public AnimalsRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Animals")
        {

        }

        public async Task<IEnumerable<Animals>> GetAnimals()
        {
            string sql = @"SELECT TOP 5 * FROM Animals";
            var results = await _sqlConnection.QueryAsync<Animals>(sql,
                transaction: _dbTransaction);
            return results;
        }
    }
}
