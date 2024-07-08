using Dapper;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class MamlzRepository : GenericRepository<Mamlz>, IMamlzRepository
    {
        private readonly IDbConnection _connection;

        public MamlzRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Mamlz>> GetRofMamlz(string param, int mm_primno)
        {
            string[] validParams = { "mm_kod", "mm_ad", "mm_cins", "mm_kod-mm_ad", "mm_birim", "mm_birim2", "mm_ad_ydil", "mm_tlmt_kod", "mm_brmgrp", "mm_orjkod",
                                    "mm_grp", "mm_stokyeri", "mm_standart", "mm_des_kod", "mm_mlz_tur", "mm_alis_dvz_kod", "mm_ted_frm_kod", "mm_tas_no", "mm_grp1_kod", "mm_birim-mm_mkt_kg" };
            string sql = "";

            if (validParams.Contains(param))
            {
                if (param == "mm_kod-mm_ad")
                {
                    sql = $@"SELECT mm_kod + ' ' + mm_ad AS s_data FROM mamlz WHERE (mm_primno = {mm_primno});";
                } 
                else if(param == "mm_birim-mm_mkt_kg")
                {
                    sql = $@"SELECT mm_birim, mm_mkt_kg FROM mamlz WHERE mm_primno = {mm_primno}";
                }
                else
                {
                    sql = $@"SELECT {param} FROM mamlz WHERE ( mm_primno = {mm_primno})";
                }
            }



            return await _connection.QueryAsync<Mamlz>(sql);
        }

        public async Task<IEnumerable<Mamlz>> GetMamlz(int an_srk_no, int an_tur, int an_mlz_tur, int an_left, string as_left_kod, string as_kod_i, string as_kod_s, int an_yok)
        {
            string sql = @$"
                            mm_kod,   
                            mm_ad,   
                            mm_cins,   
                            mm_grp,   
                            mm_primno,   
                            mm_satis_fiyat,   
                            mm_birim,   
                            mm_tur,   
                            mm_grmj2,   
                            mm_satis_dvz_kod,   
                            mm_orjkod,   
                            mm_barkod,   
                            cmpt_grp = (SELECT grp_ad FROM grup WHERE grp_primno = mm_grp_primno),   
                            mm_ad_ydil,   
                            mm_dp_no  
                        FROM 
                            mamlz  
                        WHERE 
                            (srk_no = {an_srk_no}) AND  
                            ((mm_tur = {an_tur}) OR (mm_tur < 3 AND {an_tur} = 0)) AND  
                            ((mm_mlz_tur <> '' AND {an_mlz_tur} = 1) OR {an_mlz_tur} = 0) AND  
                            (({an_left} > 0 AND (LEFT(mm_kod, {an_left}) = '{as_left_kod}')) OR {an_left} = 0) AND  
                            mm_kod BETWEEN '{as_kod_i}' AND '{as_kod_s}' AND  
                            ((mm_yok = {an_yok}) OR {an_yok} = 2)";

            return await _connection.QueryAsync<Mamlz>(sql);
        }


        public async Task<IEnumerable<Mamlz>> GetAll(int srk_no)
        {
            string sql = @$"SELECT DISTINCT mamlz.*, firma.frm_ksad FROM mamlz, firma WHERE mamlz.srk_no = '{srk_no}' AND firma.frm_kod = mamlz.mm_ted_frm_kod";
            return await _connection.QueryAsync<Mamlz, Firma, Mamlz>(sql, (mamlz, firma) =>
            {
                mamlz.firma = firma;
                return mamlz;
            }, splitOn: "compute_grp1, frm_ksad");
        }

        public async Task<IEnumerable<Mamlz>> GetMamlzYardim(Filter? filter)
        {
            string sql = $@"SELECT 
                                  mamlz.*,
                                  mamlz.mm_mas_id,
                                  cmpt_ipno = (SELECT gs_i1 FROM gnstr WHERE gnstr.srk_no = mamlz.srk_no AND gs_bcmno = 3 AND gs_kod = mm_ipno),
                                  cmpt_rct = (SELECT COUNT(DISTINCT mr_bcmno) FROM mamlzrct WHERE mr_mm_id = mm_primno),
                                  cmpt_grp = (SELECT grp_ad FROM grup WHERE grp_primno = mm_grp_primno)
                                FROM mamlz
                                WHERE 
                                  mamlz.srk_no = {filter.filterValue1} AND
                                  (
                                    (mamlz.mm_tur = {filter.filterValue2} OR (mamlz.mm_tur < 3 AND {filter.filterValue2} = 0)) AND
                                    ((mm_mlz_tur <> '' AND {filter.filterValue3} = 1) OR {filter.filterValue3} = 0) AND
                                    (
                                      ({filter.filterValue4} > 0 AND LEFT(mm_kod, {filter.filterValue4}) = '{filter.filterValue20}') OR
                                      {filter.filterValue4} = 0
                                    ) AND
                                    mamlz.mm_kod BETWEEN '{filter.filterValue21}' AND '{filter.filterValue22}' AND
                                    (mm_yok = {filter.filterValue5} OR {filter.filterValue5} = 2)
                                  );";

            return await _connection.QueryAsync<Mamlz, MamlzYardimCmpt, Mamlz>(sql, (mamlz, mamlzYardimCmpt) =>
            {
                mamlz.mamlzYardimCmpt = mamlzYardimCmpt;
                return mamlz;
            }, splitOn: "mm_mas_id,cmpt_ipno");

            /*
             filterValue1: srk_no = 1
            filterValue2: mm_tur = 1
            filterValue3: mm_mlz_tur = 0
            filterValue4: an_left = 0
            filterValue20: as_left_kod = 
            filterValue21: as_kod_i = HYD.005
            filterValue22: as_kod_s = HYD.008
            filterValue5: mm_yok = 0
             */
        }
    }
}