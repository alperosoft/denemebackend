using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class StokPrtRepository: GenericRepository<StokPrt>, IStokPrtRepository
    {
        private readonly IDbConnection _connection;

        public StokPrtRepository(IDbConnection connection): base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<decimal>> GetTotalSum(int srk_no, int bcmno, int yil, int dp_no, int mm_primno, int cl_primno, string birim)
        {
            string sql = $@"SELECT SUM(sprt_mkt_gir - sprt_mkt_cik) AS total_sum
                            FROM stokprt
                            WHERE sprt_srk_no = {srk_no}
                              AND sprt_bcmno = {bcmno}
                              AND sprt_yil = {yil}
                              AND sprt_dp_no = {dp_no}
                              AND sprt_mm_primno = {mm_primno}
                              AND sprt_cl_primno = {cl_primno}
                              AND sprt_birim = '{birim}';";
            return await _connection.QueryAsync<decimal>(sql);
        }

        public async Task<IEnumerable<StokPrt>> GetMaliyet(int srk_no, int bcmno, int yil, int dp_no)
        {
       

            string sql = $@"Select 
                                sum((sprt_mkt_gir-sprt_mkt_cik) *sprt_mlyt_fyt ) as mkt,
                                grp_ad
                                from stokprt, mamlz, grup 
                                where sprt_mm_primno= mm_primno and
                                grp_primno=mm_grp_primno and sprt_yil={yil} AND 
                                sprt_srk_no=1    group by grp_ad having mkt>0";

            //var asd = $@"SELECT 
            //               SUM((sprt_mkt_gir-sprt_mkt_cik) *sprt_mlyt_fyt ) as cmpt_mkt,
            //               grp_ad
            //              FROM stokprt, mamlz, grup 
            //              WHERE sprt_mm_primno= mm_primno and
            //               grp_primno=mm_grp_primno and
            //               sprt_srk_no={srk_no} and 
            //               sprt_bcmno={bcmno} and
            //               sprt_yil={yil} and
            //               sprt_dp_no={dp_no} and sprt_mlyt_fyt>0 
            //            GROUP BY grp_ad HAVING mkt>0";

            return await _connection.QueryAsync<StokPrt>(sql);
        }
    }
}
