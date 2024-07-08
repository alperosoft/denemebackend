using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface ILfydRepository : IGenericRepository<Lfyd>
    {
        Task<IEnumerable<Lfyd>> GetLfyd(int srk_no, string? frm_kod, string? kod1);
    }
}
