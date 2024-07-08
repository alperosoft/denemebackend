using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class VardiyaRepository : GenericRepository<Vardiya>, IVardiyaRepository
    {
        private readonly IDbConnection _connection;

        public VardiyaRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Vardiya>> GetVardiya(int srk_no)
        {
            string sql = $@"SELECT * FROM  vardiya WHERE srk_no = :srk_no";
            return await _connection.QueryAsync<Vardiya>(sql, new { srk_no });
        }
    }
}
