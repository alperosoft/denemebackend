using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class DepoRepository : GenericRepository<Depo>, IDepoRepository
    {
        private readonly IDbConnection _connection;
        public DepoRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Depo>> GetDepo(int srk_no)
        {
            string sql = $@"SELECT * FROM depo ORDER BY dp_no ASC";
            return await _connection.QueryAsync<Depo>(sql);
        }
    }
}
