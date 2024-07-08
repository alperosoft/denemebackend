using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class LbRepository : GenericRepository<Spkateg>, ILbRepository
    {
        private readonly IDbConnection _connection;

        public LbRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Lb>> GetLbAll(int srk_no)
        {
        string sql = @$"SELECT lb_kod, lb_ad FROM labelss WHERE (srk_no = :srk_no) AND (LEFT(lb_ad, 3) <> 'XXX') AND (lb_yok = 0)";

        return await _connection.QueryAsync<Lb>(sql, new { srk_no });
        }


    }
}
