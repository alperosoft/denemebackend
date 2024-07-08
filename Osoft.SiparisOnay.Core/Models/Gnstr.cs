using System.ComponentModel.DataAnnotations;

namespace Osoft.SiparisOnay.Core.Models
{
    public class Gnstr
    {
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "gs_primno  boş olamaz!")]
        public int gs_primno { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int srk_no { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int gs_bcmno { get; set; } = 0;
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string gs_kod { get; set; } = "";
        [StringLength(1200, ErrorMessage = "Karakter sayısı 1200 aşmamalıdır.")]
        public string gs_ad { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int gs_sira { get; set; } = 0;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string uk { get; set; } = "";
        public DateTime? updt { get; set; } = null;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string iuk { get; set; } = "";
        public DateTime? idt { get; set; } = null;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int gs_i1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int gs_i2 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int gs_i3 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int gs_i4 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int gs_i5 { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int gs_t1 { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int gs_t2 { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int gs_t3 { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int gs_t4 { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int gs_t5 { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal gs_d1 { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal gs_d2 { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal gs_d3 { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal gs_d4 { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal gs_d5 { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string gs_c1 { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string gs_c2 { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string gs_c3 { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string gs_c4 { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string gs_c5 { get; set; } = "";
        [StringLength(150, ErrorMessage = "Karakter sayısı 150 aşmamalıdır.")]
        public string gs_v1 { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string gs_v2 { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string gs_v3 { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string gs_v4 { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string gs_v5 { get; set; } = "";
        public DateTime? gs_trh1 { get; set; } = null;
        public DateTime? gs_trh2 { get; set; } = null;
    }
}
