using System.ComponentModel.DataAnnotations;

namespace Osoft.SiparisOnay.Core.Models
{
    public class Vardiya
    {
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        [Required(ErrorMessage = "srk_no  boş olamaz!")]
        public int srk_no { get; set; }
        [StringLength(4, ErrorMessage = "Karakter sayısı 4 aşmamalıdır.")]
        [Required(ErrorMessage = "vad_kod  boş olamaz!")]
        public string vad_kod { get; set; }
        [StringLength(15, ErrorMessage = "Karakter sayısı 15 aşmamalıdır.")]
        public string vad_ad { get; set; } = "";
        public TimeSpan? vad_bas { get; set; } = null;
        public TimeSpan? vad_bit { get; set; } = null;
        public TimeSpan? vad_gunsonu { get; set; } = null;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int vad_gunsonu_isrt { get; set; } = 0;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string uk { get; set; } = "";
        public DateTime? updt { get; set; } = null;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string iuk { get; set; } = "";
        public DateTime? idt { get; set; } = null;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        [Required(ErrorMessage = "vad_sira  boş olamaz!")]
        public int vad_sira { get; set; }

    }
}
