using System.ComponentModel.DataAnnotations;


namespace Osoft.SiparisOnay.Core.Models
{
    public class Spdalt : SpdaltCmpt
    {
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "spda_ust_primno  boş olamaz!")]
        public int spda_ust_primno { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        [Required(ErrorMessage = "spda_tur  boş olamaz!")]
        public int spda_tur { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int spda_srk_no { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int spda_bcmno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int spda_no1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int spda_no2 { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int spda_spd_sira { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        [Required(ErrorMessage = "spda_sira  boş olamaz!")]
        public int spda_sira { get; set; }
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int spda_sipno { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int spda_alt_primno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int spda_alt_bcmno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int spda_alt_no1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int spda_alt_no2 { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int spda_alt_sira { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int spda_alt_sipno { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_mkt { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_mkt_kg { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_mkt_mt { get; set; } = 0;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string uk { get; set; } = "";
        public DateTime? updt { get; set; } = null;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string iuk { get; set; } = "";
        public DateTime? idt { get; set; } = null;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int spda_cl_primno { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string spda_cl_kod { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_smkt_kg { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_smkt_mt { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int spda_smkt_top { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_sbmkt_kg { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_sbmkt_mt { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int spda_sbmkt_top { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 999.999, ErrorMessage = "Sayı 6 karakterden fazla olamaz.")]
        public decimal spda_iskonto { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 999999999999.9999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal spda_fiyat { get; set; } = 0;
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string spda_dvz_kod { get; set; } = "";
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string spda_hspbirim { get; set; } = "";
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string spda_hsptur { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int spda_vade { get; set; } = 0;
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string spda_bitis { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int spda_prs_primno { get; set; } = 0;
        [StringLength(12, ErrorMessage = "Karakter sayısı 12 aşmamalıdır.")]
        public string spda_prs_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int spda_des_primno { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string spda_des_kod { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string spda_varyant { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_brtmkt_kg { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_brtmkt_mt { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999.99, ErrorMessage = "Sayı 5 karakterden fazla olamaz.")]
        public decimal spda_fire { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string spda_lotno { get; set; } = "";
        [StringLength(6, ErrorMessage = "Karakter sayısı 6 aşmamalıdır.")]
        public string spda_mark_kod { get; set; } = "";
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string spda_cl_acik { get; set; } = "";
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string spda_aciklama { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int spda_fyt_drm { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_gel_mkt { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_gel_mt { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_gel_top { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_gid_mkt { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_gid_mt { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal spda_gid_top { get; set; } = 0;
        [StringLength(200, ErrorMessage = "Karakter sayısı 200 aşmamalıdır.")]
        public string spda_gel_acik { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,1}$", ErrorMessage = "Sayı virgülden sonra 1 haneli olmalıdır.")]
        [Range(0, 99.9, ErrorMessage = "Sayı 3 karakterden fazla olamaz.")]
        public decimal spda_kdv { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string spda_kartela { get; set; } = "";
        public DateTime? spda_tertrh { get; set; } = null;
        [StringLength(40, ErrorMessage = "Karakter sayısı 40 aşmamalıdır.")]
        public string spda_frm_sipno { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int spda_renk_dagilim { get; set; } = 0;
        public DateTime? spda_siptrh { get; set; } = null;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int spda_tlmt_id { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string spda_tlmt_kod { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int spda_cl_rpt { get; set; } = 0;

        public Spd? Spd { get; set; } = null;
        //public Mamlz? Mamlz { get; set; } = null;
        //public Spgrp? Spgrp { get; set; } = null;



    }
    public class SpdaltCmpt
    {
        public string cmpt_ambalaj { get; set; }
        public string cmpt_etiket { get; set; }
    }
}
