using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class GnstrRepository : GenericRepository<Gnstr>, IGnstrRepository
    {

        private readonly IDbConnection _conn;
        public GnstrRepository(IDbConnection conn) : base(conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<Gnstr>> Gnstr(int srk_no, int gs_bcmno)
        {
            string sql = @"
                SELECT gs_ad, gs_sira, gs_kod, gs_primno
                FROM gnstr
                WHERE srk_no = :srk_no AND gs_bcmno = :gs_bcmno";

            return await _conn.QueryAsync<Gnstr>(sql, new { srk_no, gs_bcmno });
        }

        public async Task<IEnumerable<Gnstr>> GetGnstr(int srk_no, int gs_primno)
        {
            //SELECT * FROM gnstr WHERE gs_primno = 2695 AND srk_no = 1
            string sql = @$" SELECT gs_ad, gs_sira, gs_kod, gs_primno
                FROM gnstr
                WHERE srk_no = {srk_no} AND gs_primno = {gs_primno}";

            return await _conn.QueryAsync<Gnstr>(sql);
        }
    }
}
