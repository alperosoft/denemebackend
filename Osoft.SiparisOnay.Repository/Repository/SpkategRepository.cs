using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class SpkategRepository : GenericRepository<Spkateg>, ISpkategRepository
    {
        private readonly IDbConnection _connection;

        public SpkategRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Spkateg>> GetSpkategAll(int srk_no)
        {
        string sql = @$"SELECT sk_kod, sk_ad FROM spkateg WHERE srk_no = :srk_no";

        return await _connection.QueryAsync<Spkateg>(sql, new { srk_no });
        }


    }
}
