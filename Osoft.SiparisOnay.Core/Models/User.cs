using System.ComponentModel.DataAnnotations;

namespace Osoft.SiparisOnay.Core.Models
{
    public class User : UserCmpt
    {
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        [Required(ErrorMessage = "srk_no  boş olamaz!")]
        public int srk_no { get; set; }
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        [Required(ErrorMessage = "us_kod  boş olamaz!")]
        public string us_kod { get; set; } = "";
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string us_ad { get; set; } = "";
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string us_soyad { get; set; } = "";
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string us_pasifre { get; set; } = "";
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string us_degree { get; set; } = "";
        [StringLength(200, ErrorMessage = "Karakter sayısı 200 aşmamalıdır.")]
        public string us_path { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int us_per_no { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int us_sw1 { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int us_sw2 { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int us_sw3 { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int us_sw4 { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string us_frmd_kod { get; set; } = "";
        public DateTime? us_giris_dtm { get; set; } = null;
        public DateTime? us_cikis_dtm { get; set; } = null;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string us_islt_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int us_id { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int us_usg_id { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string us_usg_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int us_urtt_id { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string us_urtt_kod { get; set; } = "";
        [StringLength(200, ErrorMessage = "Karakter sayısı 200 aşmamalıdır.")]
        public string us_device_id { get; set; } = "";
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string us_mail { get; set; } = "";
        //public Sirket Sirket { get; set; } = new Sirket();





        public Object? Where { get; set; }
    }
    public class UserCmpt
    {
        public string cmpt_token { get; set; } = "";

    }
}
