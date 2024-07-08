using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class FytturRepository : GenericRepository<Fyttur>, IFytturRepository
    {
        private readonly IDbConnection _connection;

        public FytturRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Fyttur>> GetFytturAll()
        {
            string sql = $@"SELECT fyt_id, fyt_ad FROM fyttur";
            return await _connection.QueryAsync<Fyttur>(sql);
        }
    }
}
