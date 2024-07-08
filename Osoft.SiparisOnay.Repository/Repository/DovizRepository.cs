using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class DovizRepository : GenericRepository<Doviz>, IDovizRepository
    {
        private readonly IDbConnection _connection;

        public DovizRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Doviz>> GetDovizAll()
        {
            string sql = $@"SELECT dvz_kod, dvz_ad FROM doviz";
            return await _connection.QueryAsync<Doviz>(sql);
        }
    }
}
