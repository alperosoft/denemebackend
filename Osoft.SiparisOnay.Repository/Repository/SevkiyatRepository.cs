using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class SevkiyatRepository : GenericRepository<Svkfatd>, ISevkiyatRepository
    {
        private readonly IDbConnection _connection;
        public SevkiyatRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Spkateg>> GetSevkiyat(Filter? filter)
        {
            string sql = @$"SELECT   
                               spkateg.sk_kod,   
                               spkateg.sk_ad,   
                               spkateg.sk_grp_primno,   
                               spkateg.sk_grp_kod,
                               cmpt_bmkt_kg = sum(sftd_bmkt_kg),   
                               cmpt_bmkt_mt = sum(sftd_bmkt_mt),   
                               cmpt_mkt_kg = sum(sftd_mkt_kg),   
                               cmpt_text = sk_ad + ' (' + spg_ad + ') ' ,
                               cmpt_mkt_mt = sum(sftd_mkt_mt),   
                               spd.spd_birim, 
                               spd.spd_st_kod,
                               spgrp.spg_kod,   
                               spgrp.spg_ad
                        FROM svkfatd,   
                             spd,   
                             spgrp,   
                             spkateg  
                        WHERE ( spd.spd_primno = svkfatd.sftd_spd_primno ) and  
                              ( spgrp.spg_primno = spd.spd_spg_primno ) and  
                              ( spkateg.srk_no = spd.spd_srk_no ) and  
                              ( spkateg.sk_kod = spd.spd_sk_kod ) and  
                              ( ( svkfatd.sftd_srk_no = {filter.filterValue1} ) AND  
                              ( svkfatd.sftd_bcmno = 600 ) AND  
                              ( spd.spd_st_kod = '{filter.filterValue20}' ) AND
                              ( date(sftd_trh_sevk) between '{filter.filterValue60?.ToString("yyyy-MM-dd HH:mm:ss")}' and '{filter.filterValue61?.ToString("yyyy-MM-dd HH:mm:ss")}' ) )   
                        GROUP BY spd.spd_birim,   
                                 spgrp.spg_kod,   
                                 spgrp.spg_ad,   
                                 spd.spd_st_kod,   
                                 spkateg.sk_kod,   
                                 spkateg.sk_ad,   
                                 spkateg.sk_grp_primno,   
                                 spkateg.sk_grp_kod";

            //  ( svkfatd.sftd_yil = {filter.filterValue2} ) AND  
            return await _connection.QueryAsync<Spkateg, SpkategCmpt, Spd, Spgrp, Spkateg>(sql, (spkateg, spkategCmpt, spd, spgrp) =>
            {
                spkateg.spkategCmpt = spkategCmpt;
                spkateg.spd = spd;
                spkateg.spgrp = spgrp;
                return spkateg;
            }, splitOn: "sk_grp_kod,cmpt_bmkt_kg,spd_birim,spg_kod");

        }
    }
}
