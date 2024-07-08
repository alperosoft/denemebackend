using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;
using Dapper;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class StkfRepository : GenericRepository<Stkf>, IStkfRepository
    {
        private readonly IDbConnection _conn;
        public StkfRepository(IDbConnection conn) : base(conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<Stkf>> GetTahsilat(Stkf stkf)
        {
            string sql = $@"
                            SELECT
                                sf_trh,
                                CAST(SUM((case when sf_dvz_kod<>'TL' then sf_isl_tutar * sf_kur else sf_isl_tutar end)) as DECIMAL(16,2)) as cmpt_sf_isl_tutar
                               FROM stkf  
                               WHERE ( stkf.sf_srk_no = {stkf.sf_srk_no} ) AND  
                                     ( stkf.sf_bcmno = {stkf.sf_bcmno} ) AND  
                                     ( stkf.sf_yil = {stkf.sf_yil} ) AND  
                                     ( stkf.sf_dp_no = {stkf.sf_dp_no} ) AND  
                                     ( stkf.sf_sft_tur = {stkf.sf_sft_tur} ) AND  
                                     ( stkf.sf_ba = '{stkf.sf_ba}' )   AND
                                     ( stkf.sf_trh between '2023-01-01' and '2023-01-31' )
                            GROUP BY sf_trh
                            ORDER BY sf_trh 
                            ";
            return await _conn.QueryAsync<Stkf>(sql);
        }

        public async Task<IEnumerable<Stkf>> GetList(Stkf stkf)
        {
            string sql = @$"SELECT * FROM stkf WHERE sf_primno={stkf.cmpt_sf_primno}";
            return await _conn.QueryAsync<Stkf>(sql);
        }

        public async Task<Stkf?> Find(int sf_srk_no, int sf_bcmno, int sf_no2, int sf_fist_no)
        {

            string sql = @$"SELECT * FROM stkf WHERE  sf_no2='{sf_no2}' AND sf_bcmno={sf_bcmno} AND sf_fist_no='{sf_fist_no}' AND sf_srk_no={sf_srk_no}";
            return await _conn.QueryFirstOrDefaultAsync<Stkf>(sql);
        }

        public async Task<Stkf> Next(int sf_srk_no, int sf_bcmno, int sf_no2, int sf_fist_no)
        {
            string where = "";
            if (sf_no2 > 0)
            {
                where = @$" AND sf_no2>{sf_no2} ";
            }
            string sql = @$"SELECT min(sf_primno) AS cmpt_sf_primno FROM stkf WHERE sf_primno>0 AND sf_bcmno={sf_bcmno} AND sf_fist_no='{sf_fist_no}' AND sf_srk_no={sf_srk_no} {where} ";
            return await _conn.QueryFirstAsync<Stkf>(sql);
        }

        public async Task<Stkf> Previous(int sf_srk_no, int sf_bcmno, int sf_no2, int sf_fist_no)
        {
            string where = "";
            if (sf_no2 > 0)
            {
                where = @$" AND sf_no2<{sf_no2} ";
            }
            string sql = @$"SELECT max(sf_primno) AS cmpt_sf_primno FROM stkf WHERE sf_bcmno={sf_bcmno} AND sf_fist_no='{sf_fist_no}' AND sf_srk_no={sf_srk_no} {where} ";

            return await _conn.QueryFirstAsync<Stkf>(sql);
        }
    }
}
