using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class LfydRepository : GenericRepository<Lfyd>, ILfydRepository
    {
        private readonly IDbConnection _connection;

        public LfydRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Lfyd>> GetLfyd(int srk_no, string? frm_kod, string? kod1)
        {
            string sql = @$"
        SELECT lfyd_primno,   
            lfyd_lfy_primno,   
            lfyd_srk_no,   
            lfyd_bcmno,   
            lfyd_liste,   
            lfyd_frm_kod,   
            lfyd_trh,   
            lfyd_dvz_kod,   
            lfyd_sira,   
            lfyd_grp_primno,   
            lfyd_mm_grp,   
            lfyd_mm_primno,   
            lfyd_mm_tur,   
            lfyd_mm_kod,   
            lfyd_cl_primno,   
            lfyd_cl_kod,   
            lfyd_des_primno,   
            lfyd_des_kod,   
            lfyd_prs_primno,   
            lfyd_prs_kod,   
            lfyd_listfiyat,   
            lfyd_satisfiyat,   
            listfiyatd.uk,   
            listfiyatd.updt,   
            listfiyatd.iuk,   
            listfiyatd.idt,   
            lfyd_grp_id2,   
            lfyd_grp2,   
            lfyd_kod,   
            lfyd_ad,   
            lfyd_en,   
            lfyd_grmj,   
            lfyd_kod1,   
            lfyd_kod2,   
            lfyd_acik1,   
            lfyd_acik2,   
            mamlz.mm_ad,   
            colors.cl_ad,   
            firma.frm_ksad
        FROM 
            listfiyatd
        INNER JOIN mamlz ON mamlz.mm_primno = listfiyatd.lfyd_mm_primno
        INNER JOIN colors ON colors.cl_primno = listfiyatd.lfyd_des_primno
        INNER JOIN firma ON firma.srk_no = listfiyatd.lfyd_srk_no AND firma.frm_kod = listfiyatd.lfyd_frm_kod
        WHERE 
            listfiyatd.lfyd_srk_no = {srk_no} AND
            listfiyatd.lfyd_bcmno = 131" +
            (frm_kod != null ? $" AND listfiyatd.lfyd_frm_kod = '{frm_kod}'" : string.Empty) +
            (kod1 != null ? $" AND listfiyatd.lfyd_kod1 = '{kod1}'" : string.Empty);

            return await _connection.QueryAsync<Lfyd, Mamlz, Colors, Firma, Lfyd>(sql, (lfyd, mamlz, colors, firma) =>
            {
                lfyd.Mamlz = mamlz;
                lfyd.Colors = colors;
                lfyd.Firma = firma;
                return lfyd;
            }, splitOn: "lfyd_acik2, mm_ad, cl_ad, frm_ksad");
        }

    }
}
