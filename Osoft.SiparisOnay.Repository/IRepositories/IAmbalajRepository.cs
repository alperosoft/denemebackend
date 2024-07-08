using Osoft.SiparisOnay.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Repository.IRepositories
{
    public interface IAmbalajRepository : IGenericRepository<Ambalaj>
    {
        Task<IEnumerable<Ambalaj>> GetAmbalajAll(int srk_no);
    }
}
