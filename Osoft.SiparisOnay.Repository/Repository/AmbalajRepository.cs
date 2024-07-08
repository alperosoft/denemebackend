using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class AmbalajRepository : GenericRepository<Ambalaj>, IAmbalajRepository
    {
        private readonly IDbConnection _connection;

        public AmbalajRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Ambalaj>> GetAmbalajAll(int srk_no)
        {
            string sql = $@"SELECT ab_kod, ab_ad FROM ambalaj WHERE srk_no = :srk_no AND ab_yok = 0";
            return await _connection.QueryAsync<Ambalaj>(sql, new { srk_no });
        }
    }
}
