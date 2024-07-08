using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;
using System.Dynamic;
using System.Text.Json;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class SpRepository : GenericRepository<Sp>,
    ISpRepository
    {
        private readonly IDbConnection _connection;

        public SpRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Sp>> GetSpAll(DateTime sp_siptrh, string sp_frm_kod, int ai_srk_no)
        {
            string sql = @"
      SELECT
      sp_primno,
      sp_srk_no,
      sp_bcmno,
      sp_no1,
      sp_no2,
      sp_frm_kod,
      sp_frmd_kod,
      sp_sk_kod,
      sp_referans,
      sp_siptrh,
      sp_bitis,
      sp_sde_no,
      sp_st_kod,
      sp_yuktrh,
      sp_gsip_yil,
      sp_gsip_no,
      sp_per_no,
      sp_veren,
      sp_aciklama,
      uk,
      updt,
      iuk,
      idt,
      sp_onay,
      sp_dept_no,
      sp_label_kod,
      sp_liste,
      cmpt_yuktrh = sp_yuktrh,
        sp_onaytrh,
        sp_per_no2,
        sp_ode_plan,
        sp_teslim,
        sp_onay2,
        sp_ipt_ned,
        sp_ipt_gs_id,
        sp_ihrc_tip,
        sp_afrm_id,
        sp_akom,
        sp_banh_id,
        sp_svkfrm_id,
        sp_rev,
        sp_fad_id,
        sp_asp_id,
        sp_asp_bcmno,
        sp_asp_no1,
        sp_asp_no2,
        sp_akt_trh,
        sp_nak_tut,
        sp_sig_tut,
        sp_takip_no,
        sp_onaytrh2,
        sp_ei_id,
        sp_hspdvz_kod,
        sp_islt_id,
        sp_islt_kod,
        sp_anlasma_turu,
        sp_urtt_id,
        sp_urtt_kod,
        sp_vade,
        sp_onay_aciklama,
        sp_muh_cari_kod,
        sp_ode_tur,
        sp_ulke_kod,
        sp_dosya,
        sp_veren2,
        sp_sevk_adres,
        sp_aciklama1,
        sp_aciklama2,
        sp_stop,
        sp_svk_adres,
        sp_cikis_trh
      FROM sp
      WHERE sp_srk_no =: ai_srk_no
      AND sp_siptrh =: sp_siptrh
      AND sp_frm_kod =: sp_frm_kod
      AND sp_bcmno = 150 ";

            return await _connection.QueryAsync<Sp>(sql, new
            {
                ai_srk_no,
                sp_siptrh,
                sp_frm_kod
            });
        }

        public async Task<IEnumerable<Sp>> GetSpProjeAll(int srk_no, string frm_kod)
        {
            string sql = @"SELECT sp_aciklama, sp_primno, sp_no1, sp_no2, sp_onay FROM sp WHERE sp_srk_no = :srk_no AND sp_bcmno = 45 AND sp_bitis <> 'K' AND sp_frm_kod = :frm_kod OR sp_frm_kod = '' ";
            return await _connection.QueryAsync<Sp>(sql, new
            {
                srk_no,
                frm_kod
            });
        }

        public async Task<IEnumerable<Spgrp>> GetSpgrpAll(int srk_no, int bcmno)
        {
            string sql = @"SELECT spg_primno, spg_ad FROM spgrp WHERE srk_no = :srk_no AND spg_bcmno = :bcmno";
            return await _connection.QueryAsync<Spgrp>(sql, new
            {
                srk_no,
                bcmno
            });
        }
        public async Task<IEnumerable<Sp>> GetSp(int srk_no, int bcmno, int no1, int no2)
        {
            string sql = @"
                    SELECT *
                    FROM sp
                    WHERE sp_srk_no = :srk_no AND
                          sp_bcmno = :bcmno AND
                          sp_no1 = :no1 AND
                          sp_no2 = :no2";

            return await _connection.QueryAsync<Sp>(sql, new
            {
                srk_no,
                bcmno,
                no1,
                no2
            });
        }
        public async Task<Sp> Next(int sp_srk_no, int sp_bcmno, int sp_no2, int sp_no1)
        {
            string where = "";
            if (sp_no2 > 0)
            {
                where = @$" AND sp_no2>{sp_no2} AND sp_no1 >={sp_no1}";
            }
            string sql = @$"SELECT min(sp_primno) AS cmpt_sp_primno FROM sp WHERE sp_primno>0 AND sp_bcmno={sp_bcmno}  AND sp_srk_no={sp_srk_no} {where} ";

            return await _connection.QueryFirstAsync<Sp>(sql);
        }

        public async Task<Sp> Previous(int sp_srk_no, int sp_bcmno,int sp_no2, int sp_no1)
        {
            string where = "";
            if (sp_no2 > 0)
            {
                where = @$" AND sp_no2<{sp_no2} AND sp_no1 <={sp_no1}";
            }
            string sql = @$"SELECT max(sp_primno) AS cmpt_sp_primno FROM sp WHERE sp_bcmno={sp_bcmno}  AND sp_srk_no={sp_srk_no} {where} ";

            return await _connection.QueryFirstAsync<Sp>(sql);
        }

        public async Task<IEnumerable<Sp>> GetList(Sp sp)
        {
            string sql = @$"SELECT * FROM sp WHERE sp_primno={sp.cmpt_sp_primno}";
            return await _connection.QueryAsync<Sp>(sql);
        }
         

    }
}