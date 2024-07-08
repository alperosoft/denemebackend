using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Core.Models
{
    public class Fyttur
    {
        [Key]
        public int fyt_id { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int fyt_srk_no { get; set; } = 0;
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string fyt_ad { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,5}$", ErrorMessage = "Sayı virgülden sonra 5 haneli olmalıdır.")]
        [Range(0, 99999.99999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal fyt_artis1 { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,5}$", ErrorMessage = "Sayı virgülden sonra 5 haneli olmalıdır.")]
        [Range(0, 99999.99999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal fyt_artis2 { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int fyt_vade { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,5}$", ErrorMessage = "Sayı virgülden sonra 5 haneli olmalıdır.")]
        [Range(0, 99999.99999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal fyt_isk1 { get; set; } = 0;

    }
}
