using System.ComponentModel.DataAnnotations;

namespace Osoft.SiparisOnay.Core.Models
{
    public class Grup
    {
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "grp_primno  boş olamaz!")]
        public int grp_primno { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int srk_no { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int grp_tur { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string grp_kod { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string grp_ad { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string grp_aciklama1 { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string grp_aciklama2 { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string grp_aciklama3 { get; set; } = "";
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string uk { get; set; } = "";
        public DateTime? updt { get; set; } = null;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string iuk { get; set; } = "";
        public DateTime? idt { get; set; } = null;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int grp_sira { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int grp_ust_primno { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string grp_ust_kod { get; set; } = "";

    }
}
