using System.ComponentModel.DataAnnotations;

namespace Osoft.SiparisOnay.Core.Models
{
    public class Banka
    {
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        [Required(ErrorMessage = "srk_no  boş olamaz!")]
        public int srk_no { get; set; }
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        [Required(ErrorMessage = "ban_kod  boş olamaz!")]
        public string ban_kod { get; set; }
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string ban_ad { get; set; } = "";
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string uk { get; set; } = "";
        public DateTime? updt { get; set; } = null;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string iuk { get; set; } = "";
        public DateTime? idt { get; set; } = null;
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string ban_sube { get; set; } = "";
        [StringLength(500, ErrorMessage = "Karakter sayısı 500 aşmamalıdır.")]
        public string ban_adres { get; set; } = "";
        [StringLength(15, ErrorMessage = "Karakter sayısı 15 aşmamalıdır.")]
        public string ban_telefon { get; set; } = "";
        [StringLength(15, ErrorMessage = "Karakter sayısı 15 aşmamalıdır.")]
        public string ban_fax { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string ban_webadres { get; set; } = "";

        public Object? Where { get; set; }

        public Bankahsp? Bankahsp { get; set; }

    }
}
