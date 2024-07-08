using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class BosprimnoRepository : GenericRepository<bosprimno>, IBosprimnoRepository
    {
        private readonly IDbConnection _connection;
        public BosprimnoRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }
         
        public async Task<bosprimno?> GetPrimNo(string bos_tablo, int bos_srk_no, int bos_bcmno)
        {
            string sql = $@"SELECT TOP 1 * 
                             FROM bosprimno 
                            WHERE bos_tablo='{bos_tablo}' AND bos_srk_no ={bos_srk_no} AND bos_bcmno='{bos_bcmno}'";
            return await _connection.QueryFirstOrDefaultAsync<bosprimno>(sql);
        }

       
    }
}
