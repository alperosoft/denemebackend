using System.ComponentModel.DataAnnotations;

namespace Osoft.SiparisOnay.Core.Models
{
    public class bosprimno
    {
        [StringLength(40, ErrorMessage = "Karakter sayısı 40 aşmamalıdır.")]
        [Required(ErrorMessage = "bos_tablo  boş olamaz!")]
        public string bos_tablo { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        [Required(ErrorMessage = "bos_srk_no  boş olamaz!")]
        public int bos_srk_no { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        [Required(ErrorMessage = "bos_bcmno  boş olamaz!")]
        public int bos_bcmno { get; set; }
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int bos_primno { get; set; } = 0;

    }
}
