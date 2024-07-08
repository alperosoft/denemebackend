namespace Osoft.SiparisOnay.Core.Models
{
    public class TableId
    {
        public int srk_no { get; set; }
        public int bcmno { get; set; }
        public int yil { get; set; }
        public string table_name { get; set; }
        public string? kategori { get; set; } = null;
        public string? f_set { get; set; } = null;
        public int f_id { get; set; }
        public string? aciklama { get; set; }
    }
}