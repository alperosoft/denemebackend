using Dapper;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using System.Data;

namespace Osoft.SiparisOnay.Repository.Repository
{
    public class ColorsRepository : GenericRepository<Colors>, IColorsRepository
    {
        private readonly IDbConnection _connection;
        public ColorsRepository(IDbConnection connection) : base(connection)
        {
            _connection = connection;
        }



        public async Task<IEnumerable<Colors>> GetGelenRenk(Filter? filter)
        {
            string sql = $@"SELECT top(10) colors.cl_frm_kod,   
                                        firma.frm_ksad,   
                                        cmpt_gelen_renk_say=sum(1)  
                                FROM colors,   
                                        firma  
                                WHERE ( firma.srk_no = colors.cl_srk_no ) AND  
                                        ( firma.frm_kod = colors.cl_frm_kod ) AND  
                                        ( ( colors.cl_srk_no = {filter.filterValue1} ) AND  
                                        ( colors.cl_bcmno = 400 ) AND
                                        ( colors.cl_onay_trh between '{filter.filterValue60?.ToString("yyyy-MM-dd HH:mm:ss")}' AND '{filter.filterValue61?.ToString("yyyy-MM-dd HH:mm:ss")}' )  AND
                                        (firma.frm_ksad <> ' '))
                                GROUP BY colors.cl_frm_kod,   
                                        firma.frm_ksad  ORDER BY cmpt_gelen_renk_say desc;";

            return await _connection.QueryAsync<Colors, Firma, ColorsCmpt, Colors>(sql, (colors, firma, colorsCmpt) =>
            {
                colors.firma = firma;
                colors.colorsCmpt = colorsCmpt;
                return colors;
            }, splitOn: "cl_frm_kod,frm_ksad,cmpt_gelen_renk_say");
        }

        public async Task<IEnumerable<Colors>> GetOnayRenk(Filter? filter)
        {
            string sql = $@"SELECT top(10) colors.cl_frm_kod,   
                                 firma.frm_ksad,   
                                 cmpt_onay_renk_say=sum(1)  
                            FROM colors,   
                                 firma  
                           WHERE ( firma.srk_no = colors.cl_srk_no ) AND
                                 ( firma.frm_kod = colors.cl_frm_kod ) AND
                                 ( ( colors.cl_srk_no = {filter.filterValue1} ) AND  
                                 ( colors.cl_bcmno = 400 ) AND
                                 ( colors.cl_onay_trh between '{filter.filterValue60?.ToString("yyyy-MM-dd HH:mm:ss")}' AND '{filter.filterValue61?.ToString("yyyy-MM-dd HH:mm:ss")}' )  AND
                                 (firma.frm_ksad <> ' '))
                            GROUP BY colors.cl_frm_kod,   
                                     firma.frm_ksad  ORDER BY cmpt_onay_renk_say desc;";

            return await _connection.QueryAsync<Colors, Firma, ColorsCmpt, Colors>(sql, (colors, firma, colorsCmpt) =>
            {
                colors.firma = firma;
                colors.colorsCmpt = colorsCmpt;
                return colors;
            }, splitOn: "cl_frm_kod,frm_ksad,cmpt_onay_renk_say");

        }

        public async Task<IEnumerable<Colors>> GetColorAll(int srk_no, int bcmno, int tur)
        {
            string sql = $@"SELECT cl_primno, cl_kod, cl_ad, cl_color_drm FROM colors WHERE cl_srk_no = :srk_no AND cl_bcmno = :bcmno AND cl_color_drm = :tur AND cl_yok = 0";
            return await _connection.QueryAsync<Colors>(sql, new { srk_no, bcmno, tur });
        }

        public async Task<IEnumerable<Colors>> GetColorsAll(int srk_no, int bcmno)
        {
            string sql = @"SELECT cl_primno, cl_kod, cl_ad FROM colors WHERE cl_srk_no = :srk_no AND cl_bcmno = :bcmno AND cl_yok = 0";
            return await _connection.QueryAsync<Colors>(sql, new { srk_no, bcmno });

        }

        public async Task<IEnumerable<Colors>> GetColor(int srk_no, int cl_primno)
        {
            string sql = @"SELECT cl_primno, cl_kod, cl_ad FROM colors WHERE cl_srk_no = :srk_no AND cl_primno = :cl_primno";
            return await _connection.QueryAsync<Colors>(sql, new { srk_no, cl_primno });

        }

        public async Task<IEnumerable<Colors>> GetColorsYardim(Filter? filter)
        {
            string sql = $@"
                            SELECT colors.cl_kod,           
                                   colors.cl_ad,           
                                   colors.cl_mm_kod,           
                                   colors.cl_pantone,           
                                   colors.cl_cog_kod,           
                                   colors.cl_gelis_trh,           
                                   colors.cl_gidis_trh,           
                                   colors.cl_onay_trh,           
                                   colors.cl_primno,           
                                   colors.cl_kartela_kodu,           
                                   colors.cl_rgb_red,           
                                   colors.cl_rgb_green,           
                                   colors.cl_rgb_blue,           
                                   colors.cl_sirano,           
                                   colors.cl_frm_kod,           
                                   colors.cl_islet_onay_trh,           
                                   colors.cl_cl_kod2,           
                                   colors.cl_cl_primno2,           
                                   colors.cl_yok,           
                                   colors.cl_rpt,           
                                   colors.cl_boya_tur,
                                   mamlz.mm_ad,           
                                   colorgrp.cog_ad,           
                                   firma.frm_ksad,           
                                   cmpt_rpt = (SELECT prm_no6 FROM parametre WHERE srk_no = cl_srk_no AND prm_bcmno = 400 AND prm_sira = 1),           
                                   cmpt_rgb = '',           
                                   colorfg.cfyg_ad
                            FROM colorgrp
                            RIGHT OUTER JOIN colors ON colorgrp.cog_primno = colors.cl_cog_primno,
                                 colorfg
                            RIGHT OUTER JOIN colors ON colorfg.cfyg_primno = colors.cl_cfyg_primno,
                                 firma,
                                 mamlz
                            WHERE firma.srk_no = colors.cl_srk_no
                              AND mamlz.mm_primno = colors.cl_mm_primno
                              AND firma.frm_kod = colors.cl_frm_kod
                              AND (colors.cl_srk_no = {filter.filterValue1})
                              AND (colors.cl_bcmno = {filter.filterValue2})
                              AND (colors.cl_kod BETWEEN '{filter.filterValue20}' AND '{filter.filterValue21}' )
                              AND (colors.cl_frm_kod BETWEEN '{filter.filterValue22}' AND '{filter.filterValue23}')
                              AND (colors.cl_mm_kod BETWEEN '{filter.filterValue24}' AND '{filter.filterValue25}')
                              AND (colors.cl_pantone BETWEEN '{filter.filterValue26}' AND '{filter.filterValue27}')
                              AND (colors.cl_cog_kod BETWEEN '{filter.filterValue28}' AND '{filter.filterValue29}')
                              AND (colors.cl_kartela_kodu BETWEEN '{filter.filterValue30}' AND '{filter.filterValue31}')
                              AND ((cl_onay_trh BETWEEN '{filter.filterValue32}' AND '{filter.filterValue33}') OR '{filter.filterValue32}' IS NULL)
                              AND ((cl_gelis_trh BETWEEN '{filter.filterValue34}' AND '{filter.filterValue35}') OR '{filter.filterValue34}' IS NULL)
                              AND ((cl_gidis_trh BETWEEN '{filter.filterValue36}' AND '{filter.filterValue37}') OR '{filter.filterValue36}' IS NULL)
                              AND (cl_kritik_isrt = {filter.filterValue3} OR ({filter.filterValue3} = 2))
                              AND (((cl_ad = '{filter.filterValue3}') AND {filter.filterValue4} = 1) OR {filter.filterValue4} = 0)
                              AND ((cl_color_drm = {filter.filterValue5}) OR {filter.filterValue5} = 3)

                              AND ((cl_yok = {filter.filterValue6}) OR {filter.filterValue6} = 2)
                              AND ((cl_sektor_tur = {filter.filterValue7}) OR {filter.filterValue7} = 1);
            ";

            return await _connection.QueryAsync<Colors, Mamlz, ColorGrp, Firma, ColorsCmpt, ColorFg, Colors>(sql, (colors, mamlz, colorsGrp, firma, colorsCmpt, colorFg) =>
            {
                colors.Mamlz = mamlz;
                colors.ColorGrp = colorsGrp;
                colors.firma = firma;
                colors.colorsCmpt = colorsCmpt;
                colors.ColorFg = colorFg;
                return colors;
            }, splitOn: "cl_boya_tur,mm_ad,cog_ad,frm_ksad,cmpt_rpt,cfyg_ad");
        }
    }
}
