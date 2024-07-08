using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class BankaRepository : GenericRepository<Banka>, IBankaRepository
    {
        private readonly IDbConnection _connection;

        public BankaRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Banka>> BankaAll(int srk_no)
        {
            string sql = @$"SELECT  * from banka where srk_no={srk_no}";
            return await _connection.QueryAsync<Banka>(sql);

        }
    }
}
