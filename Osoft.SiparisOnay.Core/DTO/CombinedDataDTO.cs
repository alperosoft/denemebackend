using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Core.DTO
{
    public class CombinedDataDTO

    {
        public IEnumerable<ReceteDTO> ReceteDTO { get; set; }
        public IEnumerable<SpwoUretimDTO> SpwoUretimDTO { get; set; }
        public IEnumerable<SevkiyatDTO> SevkiyatFasonDTO { get; set; }
        public IEnumerable<SevkiyatDTO> SevkiyatSatisDTO { get; set; }
        public IEnumerable<StkfdGelenUrunDTO> StkfdGelenUrunDTO { get; set; }
        public IEnumerable<GelenRenkDTO> GelenRenkDTO { get; set; }
        public IEnumerable<OnayRenkDTO> OnayRenkDTO { get; set; }
    }
}
