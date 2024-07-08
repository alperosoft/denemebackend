using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Core.DTO
{
    public record ColorsDTO(
    int cl_primno,
    string cl_kod,
    string cl_ad,
    int cl_color_drm
);
}
