using System.ComponentModel.DataAnnotations;

namespace Osoft.SiparisOnay.Core.Models
{
    public class Sp : SpCmpt
    {
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "sp_primno  boş olamaz!")]
        public int sp_primno { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sp_srk_no { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sp_bcmno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sp_no1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_no2 { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sp_frm_kod { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sp_frmd_kod { get; set; } = "";
        [StringLength(4, ErrorMessage = "Karakter sayısı 4 aşmamalıdır.")]
        public string sp_sk_kod { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sp_referans { get; set; } = "";
        public DateTime? sp_siptrh { get; set; } = null;
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string sp_bitis { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sp_sde_no { get; set; } = 0;
        [StringLength(4, ErrorMessage = "Karakter sayısı 4 aşmamalıdır.")]
        public string sp_st_kod { get; set; } = "";
        public DateTime? sp_yuktrh { get; set; } = null;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sp_gsip_yil { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_gsip_no { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_per_no { get; set; } = 0;
        [StringLength(30, ErrorMessage = "Karakter sayısı 30 aşmamalıdır.")]
        public string sp_veren { get; set; } = "";
        [StringLength(90, ErrorMessage = "Karakter sayısı 90 aşmamalıdır.")]
        public string sp_aciklama { get; set; } = "";
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string uk { get; set; } = "";
        public DateTime? updt { get; set; } = null;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string iuk { get; set; } = "";
        public DateTime? idt { get; set; } = null;
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string sp_onay { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_dept_no { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string sp_label_kod { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sp_liste { get; set; } = 0;
        public DateTime? sp_onaytrh { get; set; } = null;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_per_no2 { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string sp_ode_plan { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sp_teslim { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sp_onay2 { get; set; } = 0;
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string sp_ipt_ned { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_ipt_gs_id { get; set; } = 0;
        [StringLength(6, ErrorMessage = "Karakter sayısı 6 aşmamalıdır.")]
        public string sp_ihrc_tip { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_afrm_id { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 99999.999, ErrorMessage = "Sayı 8 karakterden fazla olamaz.")]
        public decimal sp_akom { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_banh_id { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_svkfrm_id { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sp_rev { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_fad_id { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_asp_id { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sp_asp_bcmno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sp_asp_no1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_asp_no2 { get; set; } = 0;
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string sp_dosya { get; set; } = "";
        public DateTime? sp_akt_trh { get; set; } = null;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 999999999999.9999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal sp_nak_tut { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 999999999999.9999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal sp_sig_tut { get; set; } = 0;
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string sp_takip_no { get; set; } = "";
        [StringLength(200, ErrorMessage = "Karakter sayısı 200 aşmamalıdır.")]
        public string spd_etk_aciklama { get; set; } = "";
        public DateTime? sp_onaytrh2 { get; set; } = null;
        [StringLength(300, ErrorMessage = "Karakter sayısı 300 aşmamalıdır.")]
        public string sp_aciklama1 { get; set; } = "";
        [StringLength(300, ErrorMessage = "Karakter sayısı 300 aşmamalıdır.")]
        public string sp_aciklama2 { get; set; } = "";
        [StringLength(300, ErrorMessage = "Karakter sayısı 300 aşmamalıdır.")]
        public string sp_svk_adres { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sp_stop { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_ei_id { get; set; } = 0;
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string sp_hspdvz_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_islt_id { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string sp_islt_kod { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sp_anlasma_turu { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sp_urtt_id { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sp_urtt_kod { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sp_vade { get; set; } = 0;
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string sp_onay_aciklama { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sp_ode_tur { get; set; } = 0;
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string sp_muh_cari_kod { get; set; } = "";
        [StringLength(3, ErrorMessage = "Karakter sayısı 3 aşmamalıdır.")]
        public string sp_ulke_kod { get; set; } = "";
        [StringLength(300, ErrorMessage = "Karakter sayısı 300 aşmamalıdır.")]
        public string sp_sevk_adres { get; set; } = "";
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string sp_veren2 { get; set; } = "";
        public DateTime? sp_cikis_trh { get; set; } = null;


        public Firma? Firma { get; set; }
        public Personel? Personel { get; set; }
        public Spkateg? Spkateg { get; set; }
        public Depart? depart { get; set; }

        public Object? Where { get; set; }

    }

    public class SpCmpt
    {
        public string sp_frm_kod { get; set; }
        public decimal cmpt_acik_sip_tutar { get; set; }
        public string cmpt_ahes_r1 { get; set; }
        public string cmpt_kcek_r1 { get; set; }
        public string cmpt_mcek_r1 { get; set; }
        public string cmpt_frmg_kod { get; set; }
        public string cmpt_frmg_ad { get; set; }
        public string cmpt_det_onay { get; set; }
        public decimal cmpt_spda_tutar { get; set; }
        public decimal cmpt_tutar { get; set; }
        public string cmpt_dvz_kod { get; set; }
        public string cmpt_spda_dvz_kod { get; set; }
        public decimal cmpt_tutar_mt { get; set; }
        public string cmpt_proje_ad { get; set; }
        public string cmpt_kur { get; set; }
        public int cmpt_asp_id { get; set; }
        public int cmpt_sp_primno { get; set; } = 0;

    }
}
