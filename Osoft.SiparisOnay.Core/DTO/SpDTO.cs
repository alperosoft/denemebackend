using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Core.DTO
{
    public record SpDTO(
        string sp_aciklama,
        int sp_primno,
        int sp_no1,
        int sp_no2,
        string sp_onay
    );

}
