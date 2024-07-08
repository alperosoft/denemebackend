namespace Osoft.SiparisOnay.Core.DTO
{
    public class MenuItemDTO
    {
        public string id { get; set; }
        public string text { get; set; }
        public bool expanded { get; set; }
        public string mnew_resim1 { get; set; }
        public string mnew_url { get; set; }
        public string menuPrimNo { get; set; }
        public bool selected { get; set; }
        public int treeListNumber { get; set; }
        public List<MenuItemDTO> items { get; set; }
    }
}
