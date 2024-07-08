using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class FirmaRepository : GenericRepository<Firma>, IFirmaRepository
    {
        private readonly IDbConnection _connection;

        public FirmaRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<FirmaDist>> GetFirmaDistAll(int srk_no)
        {
            string sql = $@"SELECT firmadist.frmd_kod, firmadist.frmd_ad FROM firmadist WHERE firmadist.srk_no = :srk_no";
            return await _connection.QueryAsync<FirmaDist>(sql, new { srk_no });
        }

        public async Task<IEnumerable<FirmaDist>> GetFirmaDist(int srk_no, string? frmd_kod)
        {
            string sql = $@"SELECT frmd_ad FROM firmadist WHERE frmd_kod = {frmd_kod} AND srk_no = {srk_no}";
            return await _connection.QueryAsync<FirmaDist>(sql);
        }

        public async Task<IEnumerable<Firmadr>> GetFirmadrAll(int srk_no, string frm_kod)
        {
            string sql = $@"SELECT fad_tnm, fad_frm_id, fad_id FROM firmadr WHERE fad_srk_no = :srk_no AND fad_frm_kod = :frm_kod";
            return await _connection.QueryAsync<Firmadr>(sql, new { srk_no, frm_kod });
        }

        public async Task<IEnumerable<Firma>> GetFirmaAll(int srk_no, string ktgr_kod, int frm_tur)
        {
            string sql = $@"
                    SELECT firma.srk_no,
                           firma.frm_kod,
                           firma.frm_ad,
                           firma.frm_yetkili,
                           firma.frm_ksad,
                           firma.frm_frmd_kod,
                           firma.frm_i3,
                           firma.frm_per_no,
                           firma.frm_vergno,
                           firma.frm_vergda,
                           firma.frm_sehir,
                           firma.frm_hsp_kod,
                           firma.frm_muh_cari,
                           firmagrp.frmg_ad
                    FROM firma
                    LEFT OUTER JOIN firmagrp ON firmagrp.srk_no = firma.srk_no AND firmagrp.frmg_kod = firma.frm_frmg_kod
                    WHERE firma.srk_no = {srk_no}
                      AND (firma.frm_ktgr_kod = '{ktgr_kod}')
                      AND firma.frm_tur = {frm_tur}
                ";

            return await _connection.QueryAsync<Firma, Firmagrp, Firma>(sql,  (firma, firmagrp) =>
            {
                firma.firmagrp = firmagrp;
                return firma;
            },splitOn: "frm_muh_cari,frmg_ad");
            // spl't
        }

        public async Task<IEnumerable<Firma>> GetFirma(int srk_no, string frm_kod)
        {
            string sql = @"
                                SELECT frm_kod,
                                    frm_ksad,
                                    frm_id,
                                    frm_frmd_kod,
                                    frm_per_no,
                                    frm_ktgr_kod,
                                    frm_t3,
                                    frm_yetkili,
                                    frm_ode_id
                                FROM firma
                                WHERE ( srk_no = :srk_no ) AND ( frm_kod = :frm_kod )
            ";

            return await _connection.QueryAsync<Firma>(sql, new { srk_no, frm_kod });

        }
    }
}
