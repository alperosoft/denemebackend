using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Core.Models
{
    public class Spwod
    {
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "swd_sw_primno  boş olamaz!")]
        public int swd_sw_primno { get; set; }
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int swd_spd_primno { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int swd_sipno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int swd_srk_no { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int swd_bcmno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int swd_no1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int swd_no2 { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int swd_spd_sira { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int swd_sw_wno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        [Required(ErrorMessage = "swd_sira  boş olamaz!")]
        public int swd_sira { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int swd_sde_no { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int swd_prs_primno { get; set; } = 0;
        [StringLength(12, ErrorMessage = "Karakter sayısı 12 aşmamalıdır.")]
        public string swd_prs_kod { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int swd_fyt_drm { get; set; } = 0;
        [StringLength(12, ErrorMessage = "Karakter sayısı 12 aşmamalıdır.")]
        public string swd_mak_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int swd_mak_kpst { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int swd_per_no { get; set; } = 0;
        public DateTime? swd_bastrh { get; set; } = null;
        public DateTime? swd_bittrh { get; set; } = null;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int swd_sure { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal swd_mkt_kg { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal swd_mkt_mt { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int swd_mkt_top { get; set; } = 0;
        [StringLength(300, ErrorMessage = "Karakter sayısı 300 aşmamalıdır.")]
        public string swd_aciklama { get; set; } = "";
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string swd_tamir { get; set; } = "";
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string swd_bitis { get; set; } = "";
        [StringLength(3, ErrorMessage = "Karakter sayısı 3 aşmamalıdır.")]
        public string swd_durumu { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int swd_gh_primno { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string swd_gh_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int swd_per_no2 { get; set; } = 0;
        public DateTime? swd_redtrh { get; set; } = null;
        public DateTime? swd_oktrh { get; set; } = null;
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string swd_fason_islem { get; set; } = "";
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string uk { get; set; } = "";
        public DateTime? updt { get; set; } = null;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string iuk { get; set; } = "";
        public DateTime? idt { get; set; } = null;
        public DateTime? swd_plan_trh { get; set; } = null;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int swd_plan_onc { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int swd_plan_sira { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int swd_plan_sure { get; set; } = 0;
        [StringLength(12, ErrorMessage = "Karakter sayısı 12 aşmamalıdır.")]
        public string swd_plan_mak_kod { get; set; } = "";
        public DateTime? swd_urtrh { get; set; } = null;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int swd_durus_sure { get; set; } = 0;
        [StringLength(4, ErrorMessage = "Karakter sayısı 4 aşmamalıdır.")]
        public string swd_vad_kod { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal swd_unimkt_kg { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal swd_unimkt_kg2 { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal swd_unimkt_mt { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal swd_unimkt_mt2 { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 999999999999.9999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal swd_fiyat { get; set; } = 0;
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string swd_dvz_kod { get; set; } = "";
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string swd_hspbirim { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int swd_lfyd_id { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int swd_msj { get; set; } = 0;
        [StringLength(200, ErrorMessage = "Karakter sayısı 200 aşmamalıdır.")]
        public string swd_msj_ack { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string swd_arabano { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal swd_mkt_fire { get; set; } = 0;


    }


}
