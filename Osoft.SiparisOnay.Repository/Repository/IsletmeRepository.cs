using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class IsletmeRepository : GenericRepository<Isletme>, IIsletmeRepository
    {
        private readonly IDbConnection _connection;

        public IsletmeRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Isletme>> GetIsletmeAll()
        {
            string sql = $@"SELECT islt_kod, islt_ad, islt_id FROM isletme";
            return await _connection.QueryAsync<Isletme>(sql);
        }
    }
}
