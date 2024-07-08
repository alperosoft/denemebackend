using Osoft.SiparisOnay.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IStkfdRepository : IGenericRepository<Stkfd>
    {
        Task<IEnumerable<Stkfd>> GetGelenUrun(Filter? filter);
        //Task<IEnumerable<Stkfd>> GetSatisUrun(Filter? filter);
    }
}
