namespace Osoft.SiparisOnay.Core.DTO
{
    public class MamlzYardimDTO: MamlzYardimCmpt
    {
         public string mm_kod {get; set;}
            public string mm_ad {get; set;}
            public string mm_grp {get; set;}
            public int mm_primno {get; set;}
            public decimal mm_satis_fiyat {get; set;}
            public string mm_birim {get; set;}
            public int mm_tur {get; set;}
            public decimal mm_grmj2 {get; set;}
            public string mm_satis_dvz_kod {get; set;}
            public string mm_orjkod {get; set;}
            public string mm_barkod {get; set;}
            public string mm_ad_ydil {get; set;}
            public int mm_dp_no {get; set;}
            public decimal mm_stk_mkt_gir {get; set;}
            public decimal mm_stk_mkt_cik {get; set;}
            public int mm_yok {get; set;}
            public string mm_ipno {get; set;}


            public MamlzYardimCmpt? mamlzCmpt { get; set;}
    }
    public class MamlzYardimCmpt
    {
        public string cmpt_grp { get; set; }
        public int cmpt_rct { get; set; }
        public string cmpt_ipno { get; set; }
    }


}
