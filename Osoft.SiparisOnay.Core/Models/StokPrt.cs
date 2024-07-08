using System.ComponentModel.DataAnnotations;

namespace Osoft.SiparisOnay.Core.Models
{
    public class StokPrt: Cmpt_StokPrt
    {
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        [Required(ErrorMessage = "sprt_srk_no  boş olamaz!")]
        public int sprt_srk_no { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        [Required(ErrorMessage = "sprt_bcmno  boş olamaz!")]
        public int sprt_bcmno { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        [Required(ErrorMessage = "sprt_yil  boş olamaz!")]
        public int sprt_yil { get; set; }
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        [Required(ErrorMessage = "sprt_dp_no  boş olamaz!")]
        public int sprt_dp_no { get; set; }
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        [Required(ErrorMessage = "sprt_frm_kod  boş olamaz!")]
        public string sprt_frm_kod { get; set; }
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "sprt_mm_primno  boş olamaz!")]
        public int sprt_mm_primno { get; set; }
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        [Required(ErrorMessage = "sprt_partino  boş olamaz!")]
        public string sprt_partino { get; set; }
        [StringLength(40, ErrorMessage = "Karakter sayısı 40 aşmamalıdır.")]
        [Required(ErrorMessage = "sprt_lotno  boş olamaz!")]
        public string sprt_lotno { get; set; }
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        [Required(ErrorMessage = "sprt_harmanno  boş olamaz!")]
        public string sprt_harmanno { get; set; }
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        [Required(ErrorMessage = "sprt_klt_drm  boş olamaz!")]
        public int sprt_klt_drm { get; set; }
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        [Required(ErrorMessage = "sprt_birim  boş olamaz!")]
        public string sprt_birim { get; set; }
        [StringLength(6, ErrorMessage = "Karakter sayısı 6 aşmamalıdır.")]
        [Required(ErrorMessage = "sprt_amblj_birim  boş olamaz!")]
        public string sprt_amblj_birim { get; set; }
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sprt_grp_partino { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sprt_mm_tur { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sprt_mm_kod { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sprt_mkt_gir { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal sprt_mkt_gir_mt { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_mkt_gir_top { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal sprt_mkt_gir_amb { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal sprt_brtmkt_gir { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sprt_tutar_gir { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sprt_mkt_cik { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal sprt_mkt_cik_mt { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_mkt_cik_top { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal sprt_mkt_cik_amb { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal sprt_brtmkt_cik { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sprt_tutar_cik { get; set; } = 0;
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string sprt_tup_may { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal sprt_grmj { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sprt_en { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sprt_pus { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sprt_fayn { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 999999.9999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal sprt_metretul { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_cl_primno { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sprt_cl_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_tlmt_primno { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sprt_tlmt_kod { get; set; } = "";
        [StringLength(6, ErrorMessage = "Karakter sayısı 6 aşmamalıdır.")]
        public string sprt_mark_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_spd_primno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sprt_spd_no1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_spd_sipno { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_fspd_primno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sprt_fspd_no1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_fspd_sipno { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_rspd_primno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sprt_rspd_no1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_rspd_sipno { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_saspd_primno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sprt_saspd_no1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_saspd_sipno { get; set; } = 0;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string sprt_tms_kod { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string sprt_gsb_kod { get; set; } = "";
        public DateTime? sprt_irs_trh { get; set; } = null;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sprt_irs_frm_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_irs_no { get; set; } = 0;
        [StringLength(12, ErrorMessage = "Karakter sayısı 12 aşmamalıdır.")]
        public string sprt_stk_yer1 { get; set; } = "";
        [Key]
        public int sprt_primno { get; set; }
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sprt_orgu_frm_kod { get; set; } = "";
        [StringLength(12, ErrorMessage = "Karakter sayısı 12 aşmamalıdır.")]
        public string sprt_mak_kod { get; set; } = "";
        [StringLength(500, ErrorMessage = "Karakter sayısı 500 aşmamalıdır.")]
        public string sprt_aciklama { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sprt_sp_frm_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_sa_id { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal sprt_sa_mkt { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sprt_sa_fyt { get; set; } = 0;
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string sprt_sa_dvz_kod { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sprt_sa_fyt_tl { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_sa_irsno { get; set; } = 0;
        public DateTime? sprt_sa_irs_trh { get; set; } = null;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sprt_sa_frm_kod { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal sprt_iade_mkt { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sprt_iade_tutar_tl { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sprt_mlyt_fyt { get; set; } = 0;
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string sprt_mlyt_dvz_kod { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sprt_mlyt_fyt_tl { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sprt_mlyt_tutar { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sprt_mlyt_tutar_tl { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_des_id { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sprt_des_kod { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sprt_varyant { get; set; } = "";
        [StringLength(500, ErrorMessage = "Karakter sayısı 500 aşmamalıdır.")]
        public string sprt_ack2 { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string sprt_ip_uzun { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sprt_fsw_bcmno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sprt_fsw_wno { get; set; } = 0;
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string sprt_frm_sipno { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_sfd_id { get; set; } = 0;
        public DateTime? sprt_sfd_fis_trh { get; set; } = null;
        public DateTime? sprt_sfd_utrh { get; set; } = null;
        public DateTime? sprt_amb_trh { get; set; } = null;
        public DateTime? sprt_iade_trh { get; set; } = null;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal sprt_iade_amb { get; set; } = 0;
        public DateTime? sprt_sonkul_trh { get; set; } = null;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_cfyg_id { get; set; } = 0;
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string sprt_batchno { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sprt_eirs_no { get; set; } = "";
        [StringLength(30, ErrorMessage = "Karakter sayısı 30 aşmamalıdır.")]
        public string sprt_kartela { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sprt_sw_wno { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sprt_sw_id { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string sprt_bed_set { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string sprt_bed_acik { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string sprt_bed_kod { get; set; } = "";

    }

    public class Cmpt_StokPrt
    {
        public decimal cmpt_mkt { get; set; }
    }
}
