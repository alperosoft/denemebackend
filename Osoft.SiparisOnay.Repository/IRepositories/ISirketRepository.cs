using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface ISirketRepository : IGenericRepository<Sirket>
    {
        Task<IEnumerable<Sirket>> SirketGet();
    }
}
