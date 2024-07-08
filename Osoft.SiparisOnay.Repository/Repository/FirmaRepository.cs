using Dapper;
using Microsoft.IdentityModel.Tokens;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;
using System.Runtime.InteropServices.Marshalling;

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

        public async Task<Firma> Next(int srk_no, string frm_kod)
        {
            string sql = @$"
        SELECT * 
        FROM firma
        WHERE frm_kod > '{frm_kod}' AND srk_no={srk_no}
        ORDER BY frm_kod";

            return await _connection.QueryFirstAsync<Firma>(sql, new { srk_no, frm_kod });
        }
        public async Task<Firma> Previous(int srk_no, string frm_kod)
        {
            string sql = @$"
        SELECT * 
        FROM firma
        WHERE frm_kod < '{frm_kod}' AND srk_no={srk_no}
        ORDER BY frm_kod DESC";

            return await _connection.QueryFirstAsync<Firma>(sql, new { srk_no, frm_kod });
        }

        public async Task<IEnumerable<Firma>> GetList(Firma firma)
        {
            string sql = @$"SELECT * FROM firma WHERE frm_kod='{firma.frm_kod}'";
            return await _connection.QueryAsync<Firma>(sql);
        }

        public async Task<IEnumerable<Firma>> GetFirmaAll(int srk_no, string? ktgr_kod, int frm_tur)
        {
            string sql = $@"
                    SELECT firma.*,
                           firmagrp.*
                    FROM firma
                    LEFT OUTER JOIN firmagrp ON firmagrp.srk_no = firma.srk_no AND firmagrp.frmg_kod = firma.frm_frmg_kod
                    WHERE firma.srk_no = {srk_no}
                      AND firma.frm_tur = {frm_tur}
                ";
            if (!string.IsNullOrEmpty(ktgr_kod))
            {
                sql += $@"AND firma.frm_ktgr_kod = '" + ktgr_kod + "'"; 
            }
            return await _connection.QueryAsync<Firma, Firmagrp, Firma>(sql,  (firma, firmagrp) =>
            {
                firma.firmagrp = firmagrp;
                return firma;
            },splitOn: "updt,frmg_ad");
        }

        public async Task<IEnumerable<Firma>> GetFirma(int srk_no, string frm_kod)
        {
            string sql = @"
                                SELECT *
                                FROM firma
                                WHERE ( srk_no = :srk_no ) AND ( frm_kod = :frm_kod )
            ";

            return await _connection.QueryAsync<Firma>(sql, new { srk_no, frm_kod });

        }

        public async Task<int> FirmaDelete(int srk_no, string frm_kod)
        {
            var param = new { srk_no, frm_kod };
            return await _connection.ExecuteAsync(@$"DELETE from firma where firma.srk_no=:srk_no and firma.frm_kod=:frm_kod", param);
        }
    }
}
