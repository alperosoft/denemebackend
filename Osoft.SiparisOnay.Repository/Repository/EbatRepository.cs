using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class EbatRepository : GenericRepository<Ebat>, IEbatRepository
    {
        private readonly IDbConnection _connection;

        public EbatRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Ebat>> GetEbatAll(int srk_no)
        {
            string sql = $@"SELECT eb_kod, eb_ad, eb_kalinlik, eb_en, eb_boy FROM ebat WHERE srk_no = :srk_no";
            return await _connection.QueryAsync<Ebat>(sql, new { srk_no });
        }
    }
}
