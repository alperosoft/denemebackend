using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface ISpurtRepository : IGenericRepository<Spurt>
    {
        Task<IEnumerable<Spurt>> GetOrguUretim(Filter? filter);
    }
}
