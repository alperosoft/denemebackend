namespace Osoft.SiparisOnay.Core.DTO
{
    public record SpdDTO(
        int spd_sira,
        string spd_mm_kod,
        decimal spd_mmetretul,
        decimal spd_amb_mkt,
        decimal spd_mkt,
        string spd_birim,
        decimal spd_fiyat,
        string spd_dvz_kod,
        string spd_hspbirim,
        string spd_eb_kod,
        // bitis onay
        string spd_frm_sipno


    );

}
