using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Core.DTO
{
    public record EbatDTO(
    string eb_kod,
    string eb_ad,
    decimal eb_kalinlik,
    decimal eb_en,
    decimal eb_boy
    );
}
