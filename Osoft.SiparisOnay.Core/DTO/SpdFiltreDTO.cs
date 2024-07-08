﻿namespace Osoft.SiparisOnay.Core.DTO
{
    public record SpdFiltreDTO (
        string? spd_mm_kod,
        int? spd_sp_primno,
        string? spd_tlmt_kod,
        int? spd_cl_primno,
        decimal? spd_mmetretul,
        decimal? spd_amb_mkt,
        decimal? spd_mkt,
        string? spd_birim,
        string? spd_amb_kod,
        string? spd_eb_kod,
        string? spd_frm_sipno,
        int? spd_no1,
        int? spd_no2,
        int? spd_sira,
        string? spd_frm_kod,
        string? spd_cl_kod,
        int? spd_tlmt_primno,
        string? spd_st_kod,
        string? spd_kartela,
        int? spd_i1,
        int? spd_primno,
        int? spd_mm_primno,
        decimal? spd_fiyat,
        string? spd_dvz_kod,
        int? spd_smkt_top,
        decimal? spd_smkt_kg,
        string? mm_ad,
        decimal? mm_alis_fiyat,
        string? mm_alis_dvz_kod,
        string? sp_siptrh,
        string? frm_ksad
    );
}