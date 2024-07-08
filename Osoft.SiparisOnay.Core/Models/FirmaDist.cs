using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Core.Models
{
    public class FirmaDist
    {
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        [Required(ErrorMessage = "srk_no  boş olamaz!")]
        public int srk_no { get; set; }
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        [Required(ErrorMessage = "frmd_kod  boş olamaz!")]
        public string frmd_kod { get; set; }
        [StringLength(15, ErrorMessage = "Karakter sayısı 15 aşmamalıdır.")]
        public string frmd_ad { get; set; } = "";
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string uk { get; set; } = "";
        public DateTime? updt { get; set; } = null;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string iuk { get; set; } = "";
        public DateTime? idt { get; set; } = null;
        [StringLength(150, ErrorMessage = "Karakter sayısı 150 aşmamalıdır.")]
        public string frmd_acik { get; set; } = "";


    }
}
