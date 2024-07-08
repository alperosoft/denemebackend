using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Core.Models
{
    public class Proses
    {
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "prs_primno  boş olamaz!")]
        public int prs_primno { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int srk_no { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int prs_bcmno { get; set; } = 0;
        [StringLength(12, ErrorMessage = "Karakter sayısı 12 aşmamalıdır.")]
        public string prs_kod { get; set; } = "";
        [StringLength(30, ErrorMessage = "Karakter sayısı 30 aşmamalıdır.")]
        public string prs_ad { get; set; } = "";
        [StringLength(6, ErrorMessage = "Karakter sayısı 6 aşmamalıdır.")]
        public string prs_kistanm { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int prs_sure { get; set; } = 0;
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string prs_aciklama1 { get; set; } = "";
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string prs_aciklama2 { get; set; } = "";
        [StringLength(2, ErrorMessage = "Karakter sayısı 2 aşmamalıdır.")]
        public string prs_knb { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int prs_fyt_drm { get; set; } = 0;
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string prs_hsptur { get; set; } = "";
        [StringLength(4, ErrorMessage = "Karakter sayısı 4 aşmamalıdır.")]
        public string prs_hspbrm { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999.99, ErrorMessage = "Sayı 5 karakterden fazla olamaz.")]
        public decimal prs_fire { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int prs_sira { get; set; } = 0;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string uk { get; set; } = "";
        public DateTime? updt { get; set; } = null;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string iuk { get; set; } = "";
        public DateTime? idt { get; set; } = null;
        [StringLength(6, ErrorMessage = "Karakter sayısı 6 aşmamalıdır.")]
        public string prs_tip { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int prs_uret_drm { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int prs_qual_drm { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string prs_grp_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int prs_grp_primno { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int prs_i1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int prs_i2 { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999999.999, ErrorMessage = "Sayı 13 karakterden fazla olamaz.")]
        public decimal prs_d1 { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999999.999, ErrorMessage = "Sayı 13 karakterden fazla olamaz.")]
        public decimal prs_d2 { get; set; } = 0;
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string prs_v1 { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string prs_v2 { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,1}$", ErrorMessage = "Sayı virgülden sonra 1 haneli olmalıdır.")]
        [Range(0, 999.9, ErrorMessage = "Sayı 4 karakterden fazla olamaz.")]
        public decimal prs_kdvyuz { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int prs_k_id { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string prs_muh_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int prs_gs_id { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string prs_gs_kod { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int prs_yok { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string prs_su_gs_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int prs_su_gs_id { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal prs_hiz { get; set; } = 0;

    }
}
