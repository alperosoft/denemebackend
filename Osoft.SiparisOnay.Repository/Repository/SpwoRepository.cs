using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class SpwoRepository : GenericRepository<Spwo>, ISpwoRepository
    {
        private readonly IDbConnection _connection;

        public SpwoRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Spwo>> GetUretim(Filter? filter)
        {
            string sql = $@"SELECT 
                                cmpt_mkt_kg = sum(sw_mkt_kg),
                                cmpt_grp = grp_ad
                            FROM spwod,   
                                proses,   
                                grup,   
                                spwo
                            WHERE ( proses.prs_primno = spwod.swd_prs_primno ) AND  
                                ( grup.grp_primno = proses.prs_grp_primno ) AND  
                                ( spwo.sw_primno = spwod.swd_sw_primno ) AND  
                                ( ( spwod.swd_srk_no = {filter.filterValue1} ) AND  
                                ( spwod.swd_bcmno = 100 ) AND  
                                ( Date(swd_urtrh) between '{filter.filterValue60?.ToString("yyyy-MM-dd HH:mm:ss")}' AND '{filter.filterValue61?.ToString("yyyy-MM-dd HH:mm:ss")}'))
                            GROUP BY grp_ad,grp_kod
                            ORDER BY cmpt_mkt_kg  DESC";

            return await _connection.QueryAsync<Spwo>(sql);
        }
    }
}
