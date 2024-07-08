using System.ComponentModel.DataAnnotations;

namespace Osoft.SiparisOnay.Core.Models
{
    public class kanban_board
    {
        [Key]
        public int kart_id { get; set; }
        [StringLength(255, ErrorMessage = "Karakter sayısı 255 aşmamalıdır.")]
        public string kart_text { get; set; } = "";
        [StringLength(255, ErrorMessage = "Karakter sayısı 255 aşmamalıdır.")]
        public string kart_icon { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int srk_no { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int kart_index { get; set; } = 0;
        [StringLength(255, ErrorMessage = "Karakter sayısı 255 aşmamalıdır.")]
        public string kart_url { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int menu_id { get; set; } = 0;
        public DateTime? idt { get; set; } = null;
        public DateTime? udt { get; set; } = null;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int kullanici_id { get; set; } = 0;
        [StringLength(255, ErrorMessage = "Karakter sayısı 255 aşmamalıdır.")]
        public string kullanici_kodu { get; set; } = "";

    }
}
