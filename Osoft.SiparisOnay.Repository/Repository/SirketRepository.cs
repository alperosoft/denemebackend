    using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class SirketRepository : GenericRepository<Sirket>, ISirketRepository
    {
        private readonly IDbConnection _connection;
        public SirketRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Sirket>> SirketGet()
        {
            string sql = $@"SELECT srk_no,srk_ad,srk_srk_no FROM sirket";
            return await _connection.QueryAsync<Sirket>(sql);
        }
    }
}
