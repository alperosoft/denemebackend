namespace Osoft.SiparisOnay.Core.DTO
{
    public record MamlzDTO(
            string mm_kod,
            string mm_ad,
            string mm_cins,
            string mm_birim,
            string mm_birim2,
            string mm_ad_ydil,
            string mm_tlmt_kod,
            string mm_brmgrp,
            string mm_orjkod,
            string mm_grp,
            string mm_stokyeri,
            string mm_standart,
            string mm_des_kod,
            string mm_mlz_tur,
            string mm_alis_dvz_kod,
            string mm_ted_frm_kod,
            string mm_tas_no,
            string mm_grp1_kod,
            string mm_mkt_kg
        );

    public record MamlzFilterDTO(
    string mm_kod,
    string mm_ad,
    string mm_cins,
    int mm_grp,
    int mm_primno,
    decimal mm_satis_fiyat,
    string mm_birim,
    string mm_tur,
    string mm_grmj2,
    string mm_satis_dvz_kod,
    string mm_orjkod,
    string mm_barkod,
    string cmpt_grp,
    string mm_ad_ydil,
    int mm_dp_no
    );
}
