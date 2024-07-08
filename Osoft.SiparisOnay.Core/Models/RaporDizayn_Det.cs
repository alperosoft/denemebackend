using System.ComponentModel.DataAnnotations;

namespace Osoft.SiparisOnay.Core.Models
{
    public class RaporDizayn_Det
    {
        public RaporDizayn_Det()
        {
            this.RaporDizayn_Det_Deger = new HashSet<RaporDizayn_Det_Deger>();
        }

        [Key]
        public int id { get; set; }
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int rapor_dizayn_id { get; set; } = 0;
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string colum { get; set; } = "";

        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string Operator { get; set; } = "";
        [StringLength(500, ErrorMessage = "Karakter sayısı 500 aşmamalıdır.")]
        public string deger { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string tip { get; set; } = "";
        public int tip2 { get; set; } = 0;
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string logical { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int bcmno { get; set; } = 0;
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string caption { get; set; } = "";
        public virtual ICollection<RaporDizayn_Det_Deger> RaporDizayn_Det_Deger { get; set; }
    }
}
