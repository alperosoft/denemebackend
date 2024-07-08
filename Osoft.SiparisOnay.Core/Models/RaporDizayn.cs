using System.ComponentModel.DataAnnotations;

namespace Osoft.SiparisOnay.Core.Models
{
    public class RaporDizayn
    {
        [Key]
        public int id { get; set; }
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int srk_no { get; set; } = 0;
        public string sorgu { get; set; } = "";
        [StringLength(200, ErrorMessage = "Karakter sayısı 200 aşmamalıdır.")]
        public string rapor_ad { get; set; } = "";
        [StringLength(500, ErrorMessage = "Karakter sayısı 500 aşmamalıdır.")]
        public string group_text { get; set; } = "";
        [StringLength(500, ErrorMessage = "Karakter sayısı 500 aşmamalıdır.")]
        public string group_summary { get; set; } = "";
        [StringLength(500, ErrorMessage = "Karakter sayısı 500 aşmamalıdır.")]
        public string summary { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string raporid { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sayihane { get; set; } = 0;
        [StringLength(500, ErrorMessage = "Karakter sayısı 500 aşmamalıdır.")]
        public string sayicolumn { get; set; } = "";
        public int tarihformat { get; set; } = 0;
        [StringLength(500, ErrorMessage = "Karakter sayısı 500 aşmamalıdır.")]
        public string tarihcolumn { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string kontrol { get; set; } = "";
        [StringLength(500, ErrorMessage = "Karakter sayısı 500 aşmamalıdır.")]
        public string summary_header { get; set; } = "";
        [StringLength(500, ErrorMessage = "Karakter sayısı 500 aşmamalıdır.")]
        public string firma { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string ana_tablo { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string tablo_bcmno { get; set; } = "";

    }
}
