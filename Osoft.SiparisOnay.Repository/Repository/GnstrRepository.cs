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
            string sql = @$"SELECT * from gnstr where srk_no={srk_no} and gs_bcmno={gs_bcmno}";
            return await _conn.QueryAsync<Gnstr>(sql);
        }
        public async Task<IEnumerable<Gnstr>> GetGnstr(int srk_no, List<string> gs_primno)
        {
            string gs_primnoStr = string.Join(",", gs_primno.Select(x => $"'{x}'"));

            string sql = @$"SELECT * FROM gnstr WHERE srk_no = {srk_no} AND gs_primno IN ({gs_primnoStr})";
            return await _conn.QueryAsync<Gnstr>(sql);
        }

    }
}
