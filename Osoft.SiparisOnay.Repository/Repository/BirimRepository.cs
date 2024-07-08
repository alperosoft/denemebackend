using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class BirimRepository : GenericRepository<Birim>, IBirimRepository
    {
        private readonly IDbConnection _connection;

        public BirimRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Birim>> GetBirimAll()
        {
            string sql = $@"SELECT brm_kod, brm_ad FROM birim";
            return await _connection.QueryAsync<Birim>(sql);
        }
    }
}
