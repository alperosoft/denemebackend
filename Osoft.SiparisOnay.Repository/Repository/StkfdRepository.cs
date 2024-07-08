using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class StkfdRepository : GenericRepository<Stkfd>, IStkfdRepository
    {
        private readonly IDbConnection _connection;
        public StkfdRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Stkfd>> GetSevkiyatDagilim(Filter? filter)
        {
            string sql = $@"SELECT 
                                 cmpt_sfd_mkt = sum(sfd_mkt),              
                                 colors.cl_v5 
                            FROM stkfd,   
                                 colors
                            WHERE ( colors.cl_primno = stkfd.sfd_tlmt_primno ) and  
                                 ( ( stkfd.sfd_srk_no = {filter.filterValue1} ) AND  
                                 ( stkfd.sfd_bcmno = 150 ) AND  
                                 ( stkfd.sfd_yil = 2024 ) AND  
                                 ( stkfd.sfd_trh > '{filter.filterValue60?.ToString("yyyy-MM-dd")}') AND
                                 ( stkfd.sfd_trh < '{filter.filterValue61?.ToString("yyyy-MM-dd")}') AND
                                 ( stkfd.sfd_dp_no = 20 ) ) GROUP BY colors.cl_v5;";

            return await _connection.QueryAsync<Stkfd, Colors, Stkfd>(sql, (stkfd, colors) =>
            {
                stkfd.colors = colors;
                return stkfd;
            }, splitOn: "cmpt_sfd_mkt,cl_v5");
        }

        public async Task<IEnumerable<Stkfd>> GetAylikSevkiyatDagilim(Filter? filter)
        {
            string sql = $@"  SELECT sfd_ay,
                                     sum(sfd_mkt) as cmpt_sfd_mkt
                              FROM stkfd 
                              WHERE ( ( stkfd.sfd_srk_no = {filter.filterValue1} ) AND  
                                     ( stkfd.sfd_bcmno = 150 ) AND  
                                     ( stkfd.sfd_yil = 2024 ) AND  
                                     ( stkfd.sfd_trh BETWEEN '{filter.filterValue60?.ToString("yyyy-MM-dd HH:mm:ss")}' AND '{filter.filterValue61?.ToString("yyyy-MM-dd HH:mm:ss")}') AND
                                     ( stkfd.sfd_dp_no = 20 ) ) GROUP BY sfd_ay;";

            return await _connection.QueryAsync<Stkfd>(sql);
        }

        public async Task<IEnumerable<Stkfd>> GetGelenUrun(Filter? filter)
        {

            string sql = @$"SELECT stkfd.sfd_dp_no,
       stkfd.sfd_fist_no,
       depo.dp_ad,
       fistip.fist_tanim,
       grup.grp_kod,
       grup.grp_ad,
       cmpt_kg = sum(sfd_mkt),
       cmpt_mt = sum(sfd_mkt_mt)
FROM stkfd,
     fistip,
     mamlz,
     grup,
     depo
WHERE fistip.fist_no = stkfd.sfd_fist_no
      AND mamlz.mm_primno = stkfd.sfd_mm_primno
      AND grup.grp_primno = mamlz.mm_grp_primno
      AND depo.srk_no = stkfd.sfd_srk_no
      AND depo.dp_no = stkfd.sfd_dp_no
      AND stkfd.sfd_srk_no = {filter.filterValue1}
      AND stkfd.sfd_bcmno = 200
      AND stkfd.sfd_fist_no < 40
      AND ((sfd_fist_no BETWEEN 10 AND 11 AND sfd_irs_trh BETWEEN '{filter.filterValue60?.ToString("yyyy-MM-dd HH:mm:ss")}' AND '{filter.filterValue61?.ToString("yyyy-MM-dd HH:mm:ss")}')
           OR (sfd_fist_no <> 11 AND sfd_trh BETWEEN '{filter.filterValue60?.ToString("yyyy-MM-dd HH:mm:ss")}' AND '{filter.filterValue61?.ToString("yyyy-MM-dd HH:mm:ss")}'))
      AND stkfd.sfd_fist_no <> 25
GROUP BY stkfd.sfd_dp_no,
         stkfd.sfd_fist_no,
         fistip.fist_tanim,
         grup.grp_kod,
         grup.grp_ad,
         depo.dp_ad
UNION
SELECT stkfd.sfd_dp_no,
       stkfd.sfd_fist_no,
       depo.dp_ad,
       fistip.fist_tanim,
       firma.frm_kod,
       firma.frm_ksad,
       cmpt_kg = sum(sfd_mkt),
       cmpt_mt = sum(sfd_mkt_mt)
FROM stkfd,
     fistip,
     depo,
     firma
WHERE fistip.fist_no = stkfd.sfd_fist_no
      AND depo.srk_no = stkfd.sfd_srk_no
      AND depo.dp_no = stkfd.sfd_dp_no
      AND firma.srk_no = stkfd.sfd_srk_no
      AND firma.frm_kod = stkfd.sfd_frm_kod
      AND stkfd.sfd_srk_no = {filter.filterValue1}
      AND stkfd.sfd_bcmno = 200
      AND stkfd.sfd_fist_no < 40
      AND ((sfd_fist_no BETWEEN 10 AND 11 AND sfd_irs_trh BETWEEN '{filter.filterValue60?.ToString("yyyy-MM-dd HH:mm:ss")}' AND '{filter.filterValue61?.ToString("yyyy-MM-dd HH:mm:ss")}')
           OR (sfd_fist_no <> 11 AND sfd_trh BETWEEN '{filter.filterValue60?.ToString("yyyy-MM-dd HH:mm:ss")}' AND '{filter.filterValue61?.ToString("yyyy-MM-dd HH:mm:ss")}'))
GROUP BY stkfd.sfd_dp_no,
         stkfd.sfd_fist_no,
         fistip.fist_tanim,
         depo.dp_ad,
         firma.frm_kod,
         firma.frm_ksad";

            //      AND stkfd.sfd_yil = {filter.filterValue2}


            return await _connection.QueryAsync<Stkfd,Depo,Fistip,Grup, Stkfd>(sql, (stkfd, depo, fistip, grup) =>
            {
                stkfd.depo = depo;
                stkfd.fistip = fistip;
                stkfd.grup = grup;
                return stkfd;
            },splitOn: "sfd_fist_no,dp_ad,fist_tanim,grp_kod,cmpt_kg");
        }

        //public async Task<IEnumerable<Stkfd>> GetSatisUrun(Filter? filter)
        //{

        //    //filter.filterValue3 = filter.filterValue3 == 0 ? null : filter.filterValue3;
        //    //filter.filterValue4 = filter.filterValue4 == 0 ? null : filter.filterValue4;
        //    //filter.filterValue5 = filter.filterValue5 == 0 ? null : filter.filterValue5;


        //    string sql = $@"SELECT stkfd.sfd_dp_no,   
        //                       stkfd.sfd_fist_no,   
        //                       depo.dp_ad,   
        //                       fistip.fist_tanim,   
        //                       grup.grp_kod,   
        //                       grup.grp_ad,   
        //                       cmpt_kg = sum(sfd_mkt),   
        //                       cmpt_mt = sum(sfd_mkt_mt)  
        //                FROM stkfd,   
        //                     fistip,   
        //                     mamlz,   
        //                     grup,   
        //                     depo  
        //                WHERE fistip.fist_no = stkfd.sfd_fist_no   
        //                  AND mamlz.mm_primno = stkfd.sfd_mm_primno   
        //                  AND grup.grp_primno = mamlz.mm_grp_primno   
        //                  AND depo.srk_no = stkfd.sfd_srk_no   
        //                  AND depo.dp_no = stkfd.sfd_dp_no   
        //                  AND stkfd.sfd_srk_no = {filter.filterValue1}  
        //                  AND stkfd.sfd_bcmno = 500  
        //                  AND stkfd.sfd_yil = {filter.filterValue2}  
        //                  AND stkfd.sfd_trh BETWEEN '{filter.filterValue60?.ToString("yyyy-MM-dd HH:mm:ss")}' AND '{filter.filterValue61?.ToString("yyyy-MM-dd HH:mm:ss")}'  
        //                  AND (stkfd.sfd_fist_no = {filter.filterValue3} OR  
        //                       stkfd.sfd_fist_no = {filter.filterValue4} OR  
        //                       stkfd.sfd_fist_no = {filter.filterValue5})   
        //                GROUP BY stkfd.sfd_dp_no,   
        //                         stkfd.sfd_fist_no,   
        //                         fistip.fist_tanim,   
        //                         grup.grp_kod,   
        //                         grup.grp_ad,   
        //                         depo.dp_ad
        //                ";
        //    return await _connection.QueryAsync<Stkfd, Depo, Fistip, Grup,StkfdCmpt,Stkfd>(sql, (stkfd, depo, fistip, grup, stkfdCmpt) =>
        //    {
        //        stkfd.depo = depo;
        //        stkfd.fistip = fistip;
        //        stkfd.grup = grup;
        //        stkfd.stkfdCmpt = stkfdCmpt;
        //        return stkfd;
        //    },splitOn: "sfd_fist_no,dp_ad,fist_tanim,grp_ad,cmpt_mt");
        //}
    }
}
