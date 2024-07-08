using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Core.DTO
{
    public class SevkiyatDTO
    {
        public string cmpt_text { get; set; } = "";
        public decimal total_cmpt_bmkt_kg { get; set; }
        public decimal total_cmpt_mkt_kg { get; set; }
    }
}
