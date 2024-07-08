using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Core.Models
{
    public class Spkateg
    {
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        [Required(ErrorMessage = "srk_no  boş olamaz!")]
        public int srk_no { get; set; }
        [StringLength(4, ErrorMessage = "Karakter sayısı 4 aşmamalıdır.")]
        [Required(ErrorMessage = "sk_kod  boş olamaz!")]
        public string sk_kod { get; set; }
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sk_ad { get; set; } = "";
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string uk { get; set; } = "";
        public DateTime? updt { get; set; } = null;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string iuk { get; set; } = "";
        public DateTime? idt { get; set; } = null;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sk_ucr_drm { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sk_tmr_drm { get; set; } = 0;
        [StringLength(4, ErrorMessage = "Karakter sayısı 4 aşmamalıdır.")]
        public string sk_st_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sk_grp_primno { get; set; } = 0;
        [StringLength(4, ErrorMessage = "Karakter sayısı 4 aşmamalıdır.")]
        public string sk_grp_kod { get; set; } = "";

        public SpkategCmpt? spkategCmpt { get; set; }
        public Spd? spd { get; set; }
        public Spgrp? spgrp { get; set; }

    }

    public class SpkategCmpt
    {
        public decimal cmpt_bmkt_kg { get; set; }
        public decimal cmpt_bmkt_mt { get; set; }
        public decimal cmpt_mkt_kg { get; set; }
        public string cmpt_text { get; set; }
        public decimal cmpt_mkt_mt { get; set; }
    }
}
