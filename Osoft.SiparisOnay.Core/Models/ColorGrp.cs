using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Core.Models
{
    public class ColorGrp
    {
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "cog_primno  boş olamaz!")]
        public int cog_primno { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int srk_no { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int cog_bcmno { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string cog_kod { get; set; } = "";
        [StringLength(30, ErrorMessage = "Karakter sayısı 30 aşmamalıdır.")]
        public string cog_ad { get; set; } = "";
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string uk { get; set; } = "";
        public DateTime? updt { get; set; } = null;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string iuk { get; set; } = "";
        public DateTime? idt { get; set; } = null;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int cog_sira { get; set; } = 0;
         
    }
}
